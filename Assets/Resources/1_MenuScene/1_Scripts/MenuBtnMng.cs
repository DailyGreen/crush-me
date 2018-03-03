using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBtnMng : MonoBehaviour
{
    public Earth EarthSc = null;

    public GameObject ExitGams = null;
    public GameObject BackGroundGams = null;
    public GameObject[] SoundOnOffGams = null;
    public GameObject CreditPopUpGams = null;

    public Transform SettingPopUpTr = null;

    public Animator ExitAni = null;

    public Image[] JoystickPosImg = null;

    bool bPopUpAccess = false;
    bool bExit = false;
    public bool bExitPos = false;

    void Update()
    {
        //Debug.Log(EarthSc.bEarthTouchAccess);
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
            }

            if (!bExit && !bPopUpAccess)
            {
                ExitGams.SetActive(true);
                ExitAni.enabled = true;
                EarthSc.bEarthTouchAccess = true;
                bExit = true;
                Debug.Log("QWQEQWEQWEQ");
            }

            //if (EarthSc.bEarthTouchAccess) 
            //{
            //    CreditExit();
            //    Debug.Log("ASDFASDFADSFADSFA");
            //}
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
        }
    }

    public void SettingCloseBtn()
    {
        SettingPopUpTr.localPosition = new Vector2(800f, 0f);
        BackGroundGams.SetActive(false);
        StartCoroutine(PopUpControl());
        //bPopUpAccess = false;
    }

    public void SoundOn()
    {
        if (SSoundMng.I.bSoundOnOff)
            SSoundMng.I.Play("Main", false, true);

        SSoundMng.I.bSoundOnOff = false;
        SoundOnOffGams[0].SetActive(true);
        SoundOnOffGams[1].SetActive(false);
    }

    public void SoundOff()
    {
        SSoundMng.I.Stop();
        SSoundMng.I.bSoundOnOff = true;
        SoundOnOffGams[0].SetActive(false);
        SoundOnOffGams[1].SetActive(true);
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
    }

    public void CreditExit()
    {
        EarthSc.bEarthTouchAccess = false;        /////////////////////////////////////////
        CreditPopUpGams.SetActive(false);
        EarthSc.bEasterEggPlay = false;
        //++EarthSc.nEarthClickNum;
        EarthSc.nEarthClickNum = 0;
    }

    IEnumerator PopUpControl()
    {
        yield return new WaitForSeconds(0.1f);
        bPopUpAccess = false;
    }
}
