using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBtnMng : MonoBehaviour
{
    public GameObject ExitGams;
    public GameObject BackGroundGams;
    public GameObject[] SoundOnOffGams;
    public Transform SettingPopUpTr;
    public Animator ExitAni;
    public Image[] JoystickPosImg;
    bool bPopUpAccess = false;
    bool bExit = false;
    public bool bExitPos = false;
    void Update()
    {
        if (!SSoundMng.I.bJoyPos)
        {
            SSoundMng.I.nJoyStickNum = 0;
        }

        if (SSoundMng.I.bJoyPos)
        {
            SSoundMng.I.nJoyStickNum = 1;
        }

        if (bPopUpAccess)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SettingCloseBtn();
                BackGroundGams.SetActive(false);
            }
        }

        if (!bExit && !bPopUpAccess)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ExitGams.SetActive(true);
                ExitAni.enabled = true;
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
    }
    IEnumerator PopUpControl()
    {
        yield return new WaitForSeconds(0.1f);
        bPopUpAccess = false;
    }
}
