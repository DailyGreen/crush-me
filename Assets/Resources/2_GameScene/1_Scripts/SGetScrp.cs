using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SGetScrp : MonoBehaviour
{

    public Text HightTimeText;
    int nHightTime;
    void Awake()
    {
        nHightTime = PlayerPrefs.GetInt("Time");       // 시간
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HightTimeText.text = nHightTime.ToString();
    }
}
