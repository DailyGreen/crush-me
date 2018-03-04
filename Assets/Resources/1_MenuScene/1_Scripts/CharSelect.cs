using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelect : MonoBehaviour {


    public void Char0()
    {
        SSoundMng.I.nCharNum = 0;
        Debug.Log("기본");
    }

    public void Char1()
    {
        SSoundMng.I.nCharNum = 1;
        Debug.Log("보라");
    }

    public void Char2()
    {
        SSoundMng.I.nCharNum = 2;
        Debug.Log("빨강");
    }

    public void Char3()
    {
        SSoundMng.I.nCharNum = 3;
        Debug.Log("파랑");
    }

    public void Char4()
    {
        SSoundMng.I.nCharNum = 4;
        Debug.Log("노랑");
    }

    public void Char5()
    {
        SSoundMng.I.nCharNum = 5;
        Debug.Log("하늘");
    }

    public void Char6()
    {
        SSoundMng.I.nCharNum = 6;
        Debug.Log("회색");
    }

    public void Char7()
    {
        SSoundMng.I.nCharNum = 7;
        Debug.Log("스뼤샬");
    }

}
