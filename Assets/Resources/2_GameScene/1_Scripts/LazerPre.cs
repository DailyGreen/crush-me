using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerPre : MonoBehaviour {
    public GameObject LazerGams;
    public GameObject LazerLine;
    public Vector3 LazerPos;
    public float[] fPosValue;


    void Start()
    {
        LazerPosSet();
        LazerNotice();
    }

    void LazerPosSet()
    {
        fPosValue[2] = Random.Range(0, 180);
        if (fPosValue[2] <= 20 && fPosValue[2] >= -20)
        {
            fPosValue[1] = Random.Range(-2.5f, 2.5f);
        }
        else if (fPosValue[2] >= 160 && fPosValue[2] <= -160)
        {
            fPosValue[1] = Random.Range(-2.5f, 2.5f);
        }
        else
        {
            fPosValue[0] = Random.Range(-2.4f, 2.4f);
            fPosValue[1] = Random.Range(-4f, 4f);
        }
    }

    void LazerNotice()
    {
        LazerLine.transform.localPosition = new Vector3(fPosValue[0], fPosValue[1], 0f);
        LazerLine.transform.localEulerAngles = new Vector3(0f, 0f, fPosValue[2]);
        StartCoroutine(Lazer());
    }

    void LazerComeOut()
    {
        LazerGams.transform.localPosition = new Vector3(fPosValue[0], fPosValue[1], 0f);
        LazerGams.transform.localEulerAngles = new Vector3(0f, 0f, fPosValue[2]);
        LazerGams.SetActive(true);
    }

    IEnumerator Lazer()
    {
        yield return new WaitForSeconds(1f);
        LazerLine.transform.localPosition = new Vector3(-100f, 0f, 0f);
        LazerComeOut();
    }

}
