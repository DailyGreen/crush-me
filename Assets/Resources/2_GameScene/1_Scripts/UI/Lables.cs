using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lables : MonoBehaviour
{
    public Text TimeText;
    public Text ResultTime;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeText.text = SGameMng.I.nTimeCount.ToString() + " 초";
        ResultTime.text = SGameMng.I.nTimeCount.ToString() + " 초";
    }
}