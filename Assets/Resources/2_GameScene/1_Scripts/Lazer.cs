using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{

    public GameObject LazerGams;
    public GameObject LazerLine;
    public Vector3 LazerPos;
    public float[] fPosValue;

    // Use this for initialization

    void LazerPosSet()
    {
        fPosValue[0] = Random.Range(-2.4f, 2.4f);
        fPosValue[1] = Random.Range(-4.5f, 4.5f);
        fPosValue[2] = Random.Range(0, 180);
    }

    void LazerNotice()
    {
        LazerLine.transform.localPosition = new Vector3(fPosValue[0], fPosValue[1], 0f);
        LazerLine.transform.localEulerAngles = new Vector3(0f, 0f, fPosValue[2]);
    }

    void LazerComeOut()
    {
        LazerGams.transform.localPosition = new Vector3(fPosValue[0], fPosValue[1], 0f);
        LazerGams.transform.localEulerAngles = new Vector3(0f, 0f, fPosValue[2]);
        LazerGams.SetActive(true);
    }

    public IEnumerator LazerUse()
    {
        LazerPosSet();
        yield return new WaitForSeconds(5f);
        LazerNotice();
        yield return new WaitForSeconds(1f);
        LazerLine.transform.localPosition = new Vector3(-100f, 0f, 0f);
        LazerComeOut();
        StartCoroutine(LazerUse());
    }

}