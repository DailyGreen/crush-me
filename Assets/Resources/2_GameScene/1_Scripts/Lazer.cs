using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{

    public GameObject LazerPrefab;

    public IEnumerator LazerIns()
    {
        yield return new WaitForSeconds(SGameMng.I.fLazerTime);
        if (!SGameMng.I.bPuaseBtn)
            Instantiate(LazerPrefab, transform);

        StartCoroutine(LazerIns());
    }

}