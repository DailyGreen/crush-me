using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lables : MonoBehaviour
{
    public Text TimeText;
    public Text ResultTime;
    public TextMeshProUGUI CreditText;

    void Update()
    {
        TimeText.text = SGameMng.I.nTimeCount.ToString() + " 초";
        ResultTime.text = SGameMng.I.nTimeCount.ToString() + " 초";
        CreditText.text = SSoundMng.I.nAC.ToString();
    }
}