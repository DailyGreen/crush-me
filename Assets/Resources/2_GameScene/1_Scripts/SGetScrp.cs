using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SGetScrp : MonoBehaviour
{

    public Text HightTimeText;

    void Update()
    {
        SGameMng.I.nHightTimeCount = PlayerPrefs.GetInt("HightTime");       // 시간
        HightTimeText.text = SGameMng.I.nHightTimeCount.ToString() + " 초";
    }
}
