using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SGetScrp : MonoBehaviour
{

    public Text HightTimeText;

    void Update()
    {
        PlayerPrefs.SetInt("Credit", SSoundMng.I.nAC) ;
        SGameMng.I.nHightTimeCount = PlayerPrefs.GetInt("HightTime");       // 시간
        HightTimeText.text = SGameMng.I.nHightTimeCount.ToString() + " 초";

        if (SGameMng.I.nTimeCount > SGameMng.I.nHightTimeCount)
        {
            PlayerPrefs.SetInt("HightTime", SGameMng.I.nTimeCount);
        }
    }
}
