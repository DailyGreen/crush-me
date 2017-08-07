using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{

    public GameObject LazerGams;
    public Vector3 LazerPos;
    public float[] fPosValue;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(LazerUse());
    }

    void LazerPosSet()
    {
        fPosValue[0] = Random.Range(-2.4f, 2.4f);
        fPosValue[1] = Random.Range(-4.5f, 4.5f);
        fPosValue[2] = Random.Range(0, 180);
        LazerGams.transform.localPosition = new Vector3(fPosValue[0], fPosValue[1], 0f);
        LazerGams.transform.localEulerAngles = new Vector3(0f, 0f, fPosValue[2]);
        LazerGams.SetActive(true);
    }

    IEnumerator LazerUse()
    {
        yield return new WaitForSeconds(5f);
        LazerPosSet();
        yield return new WaitForSeconds(5f);
        StartCoroutine(LazerUse());
    }

}