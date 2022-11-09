using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCount : MonoBehaviour
{
    public LazerPool LazerSc = null;
    public Text CountText = null;
    public SPlayerMove HeroSc = null;
    public GameObject PauseBtnGams = null;
    public GameObject GameTimeLable = null;
    bool bLazerCorutineUse = false;
    int nCount = 10;

    void Update()
    {
        if (SGameMng.I.TimeCtrl((int)E_TIME.E_COUNT, 1f) && nCount > 0)
        {
            nCount--;
            CountText.text = nCount.ToString();
        }

        if (nCount <= 0)
        {
            SGameMng.I.bStartCheck = true;
            HeroSc.bCountSetCom = true;
            CountText.text = "START!";
            StartCoroutine(TextEnable());
            if (!bLazerCorutineUse)
            {
                StartCoroutine(SGameMng.I.LazerSpeedUp());
                StartCoroutine(LazerSc.LazerIns());
                bLazerCorutineUse = true;
            }
        }
    }

    IEnumerator TextEnable()
    {
        yield return new WaitForSeconds(1f);
        CountText.enabled = false;
        GameTimeLable.SetActive(true);
        PauseBtnGams.SetActive(true);
    }
}
