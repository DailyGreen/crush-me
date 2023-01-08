using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    public static void Log(string str, string color)
    {
        Debug.Log($"<color={color}>{str}</color");
    }
}
