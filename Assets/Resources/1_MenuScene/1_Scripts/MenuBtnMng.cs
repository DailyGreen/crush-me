using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBtnMng : MonoBehaviour
{
    public Earth EarthSc = null;
    public Rocket RocketSc = null;

    public GameObject ExitGams = null;
    public GameObject BackGroundGams = null;
    public GameObject[] SoundOnOffGams = null;
    public GameObject[] SfxSoundOnOffGame = null;
    public GameObject CreditPopUpGams = null;

    public Transform SettingPopUpTr = null;

    public Animator ExitAni = null;

    public Image[] JoystickPosImg = null;

    public bool bExit = false;
    public bool bExitPos = false;
    bool bPopUpAccess = false;

    void Start()
    {
        if (SSoundMng.I.bBackGroundSound) SoundOnOffGams[0].SetActive(true);
        else SoundOnOffGams[1].SetActive(true);

        if (SSoundMng.I.bEffectSound) SfxSoundOnOffGame[0].SetActive(true);
        else SfxSoundOnOffGame[1].SetActive(true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F2))   // 이거 쓰나?
        {
            Debug.Log("test");
            SSoundMng.I.bEffectSound = false;
        }
        if (!SSoundMng.I.bJoyPos)
        {
            SSoundMng.I.nJoyStickNum = 0;
        }
        else
        {
            SSoundMng.I.nJoyStickNum = 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (bPopUpAccess)
            {
                SettingCloseBtn();
                BackGroundGams.SetActive(false);
                RocketSc.bCharSelectOn = false;
            }

            if (!bExit && !bPopUpAccess && !EarthSc.bEasterEggPlay)
            {
                ExitGams.SetActive(true);
                ExitAni.enabled = true;
                EarthSc.bEarthTouchAccess = true;
                RocketSc.bCharSelectOn = true;
                bExit = true;
            }

        }

        if (bExitPos)
        {
            ExitGams.transform.Translate(Vector2.left * 2000f * Time.deltaTime);
            if (ExitGams.transform.localPosition.x <= -800f)
            {
                ExitGams.SetActive(false);
                bExitPos = false;
                bExit = false;
            }
        }
    }

    public void BackGroundBtn()
    {
        if (bPopUpAccess)
        {
            SettingCloseBtn();
            BackGroundGams.SetActive(false);
        }
    }

    public void SettingBtn()
    {
        if (!bPopUpAccess && !bExit)
        {
            SettingPopUpTr.localPosition = Vector2.zero;
            BackGroundGams.SetActive(true);
            bPopUpAccess = true;
            RocketSc.bCharSelectOn = true;
        }
    }

    public void SettingCloseBtn()
    {
        SettingPopUpTr.localPosition = new Vector2(800f, 0f);
        BackGroundGams.SetActive(false);
        StartCoroutine(PopUpControl());
        RocketSc.bCharSelectOn = false;
    }

    public void SoundOn()
    {
        SSoundMng.I.MainAudio.Play();
        SSoundMng.I.bBackGroundSound = true;
        SoundOnOffGams[0].SetActive(true);
        SoundOnOffGams[1].SetActive(false);
    }

    public void SoundOff()
    {
        SSoundMng.I.bBackGroundSound = false;
        SoundOnOffGams[0].SetActive(false);
        SoundOnOffGams[1].SetActive(true);
    }

    public void SfxSoundOn()
    {
        SSoundMng.I.bEffectSound = true;
        SfxSoundOnOffGame[0].SetActive(true);
        SfxSoundOnOffGame[1].SetActive(false);
    }

    public void SfxSoundOff()
    {
        SSoundMng.I.bEffectSound = false;
        SfxSoundOnOffGame[0].SetActive(false);
        SfxSoundOnOffGame[1].SetActive(true);
    }

    public void JoyStickLeft()
    {
        SSoundMng.I.bJoyPos = false;
        JoystickPosImg[0].color = new Color(255f, 255f, 255f, 255f);
        JoystickPosImg[1].color = new Color(255f, 255f, 255f, 100 / 255f);
    }

    public void JoyStickRight()
    {
        SSoundMng.I.bJoyPos = true;
        JoystickPosImg[0].color = new Color(255f, 255f, 255f, 100 / 255f);
        JoystickPosImg[1].color = new Color(255f, 255f, 255f, 255f);
    }

    public void ExitYes()
    {
        Application.Quit();
    }

    public void ExitNo()
    {
        bExitPos = true;
        EarthSc.bEarthTouchAccess = false;
        RocketSc.bCharSelectOn = false;
    }

    public void CreditExit()
    {
        EarthSc.bEarthTouchAccess = false;
        CreditPopUpGams.SetActive(false);
        StartCoroutine(EarthSc.EasterEggDelay());
        RocketSc.bCharSelectOn = false;
        EarthSc.nEarthClickNum = 0;
    }

    public void CharSelectCloseBtn()
    {
        RocketSc.CharSelectGams.SetActive(false);
        RocketSc.bCharSelectOn = false;
        bExit = false;
        EarthSc.bEarthTouchAccess = false;
    }

    IEnumerator PopUpControl()
    {
        yield return new WaitForSeconds(0.1f);
        bPopUpAccess = false;
    }
}
