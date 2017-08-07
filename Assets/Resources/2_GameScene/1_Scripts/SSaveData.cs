using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSaveData : MonoBehaviour
{
    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Time", SGameMng.I.nTimeCount);
    }
}
