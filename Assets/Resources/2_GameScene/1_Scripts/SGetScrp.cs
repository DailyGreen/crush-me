using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SGetScrp : MonoBehaviour
{

    public Text HightTimeText;
    void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SGameMng.I.nHightTimeCount = PlayerPrefs.GetInt("HightTime");       // 시간
        HightTimeText.text = SGameMng.I.nHightTimeCount.ToString() + " 초";
    }
}
