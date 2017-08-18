using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{

    public GameObject LazerPrefab;


    void Start()
    {

    }

    void Update()
    {

    }

    public IEnumerator LazerIns()
    {
        yield return new WaitForSeconds(SGameMng.I.fLazerTime);
        if (!SGameMng.I.bPuaseBtn)
            Instantiate(LazerPrefab, transform);

        StartCoroutine(LazerIns());
    }

}