using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lables : MonoBehaviour
{
    public Text TimeText;
    public Text ResultTime;

    void Update()
    {
        TimeText.text = SGameMng.I.nTimeCount.ToString() + " 초";
        ResultTime.text = SGameMng.I.nTimeCount.ToString() + " 초";
    }
}