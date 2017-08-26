using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBtnMng : MonoBehaviour
{

    public GameObject[] SoundOnOffGams;
    public Transform SettingPopUpTr;
    public Image[] JoystickPosImg;
    bool bPopUpAccess = false;

    void Start()
    {

    }

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

    }

    public void SettingBtn()
    {
        if (!bPopUpAccess)
        {
            SettingPopUpTr.localPosition = Vector2.zero;
            bPopUpAccess = true;
        }
    }

    public void SettingCloseBtn()
    {
        SettingPopUpTr.localPosition = new Vector2(800f, 0f);
        bPopUpAccess = false;
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

}
