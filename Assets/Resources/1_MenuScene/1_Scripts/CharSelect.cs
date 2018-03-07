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
        if (SSoundMng.I.bCharLock[1])
        {
            SSoundMng.I.nCharNum = 1;
            Debug.Log("보라");
        }
        else
        {
            if (SSoundMng.I.nCredit >= 100)
            {
                SSoundMng.I.nCredit -= 100;
                SSoundMng.I.bCharLock[1] = false;
            }
            else if (SSoundMng.I.nCredit < 100)
            {
                Debug.Log("크레딧이 부족합니다.");
            }

        }
        Debug.Log(SSoundMng.I.bCharLock[1]);
    }

    public void Char2()
    {
        if (SSoundMng.I.bCharLock[2])
        {
            SSoundMng.I.nCharNum = 2;
            Debug.Log("빨강");
        }
        else
        {
            if (SSoundMng.I.nCredit >= 100)
            {
                SSoundMng.I.nCredit -= 100;
                SSoundMng.I.bCharLock[2] = false;
            }
            else if (SSoundMng.I.nCredit < 100)
            {
                Debug.Log("크레딧이 부족합니다.");
            }

        }
        Debug.Log(SSoundMng.I.bCharLock[2]);
    }

    public void Char3()
    {
        if (SSoundMng.I.bCharLock[3])
        {
            SSoundMng.I.nCharNum = 3;
            Debug.Log("파랑");
        }
        else
        {
            if (SSoundMng.I.nCredit >= 100)
            {
                SSoundMng.I.nCredit -= 100;
                SSoundMng.I.bCharLock[3] = false;
            }
            else if (SSoundMng.I.nCredit < 100)
            {
                Debug.Log("크레딧이 부족합니다.");
            }

        }
        Debug.Log(SSoundMng.I.bCharLock[3]);
    }

    public void Char4()
    {
        if (SSoundMng.I.bCharLock[4])
        {
            SSoundMng.I.nCharNum = 4;
            Debug.Log("노랑");
        }
        else
        {
            if (SSoundMng.I.nCredit >= 100)
            {
                SSoundMng.I.nCredit -= 100;
                SSoundMng.I.bCharLock[4] = false;
            }
            else if (SSoundMng.I.nCredit < 100)
            {
                Debug.Log("크레딧이 부족합니다.");
            }

        }
        Debug.Log(SSoundMng.I.bCharLock[4]);
    }

    public void Char5()
    {
        if (SSoundMng.I.bCharLock[5])
        {
            SSoundMng.I.nCharNum = 5;
            Debug.Log("하늘");
        }
        else
        {
            if (SSoundMng.I.nCredit >= 100)
            {
                SSoundMng.I.nCredit -= 100;
                SSoundMng.I.bCharLock[5] = false;
            }
            else if (SSoundMng.I.nCredit < 100)
            {
                Debug.Log("크레딧이 부족합니다.");
            }

        }
        Debug.Log(SSoundMng.I.bCharLock[5]);
    }

    public void Char6()
    {
        if (SSoundMng.I.bCharLock[6])
        {
            SSoundMng.I.nCharNum = 6;
            Debug.Log("회색");
        }
        else
        {
            if (SSoundMng.I.nCredit >= 100)
            {
                SSoundMng.I.nCredit -= 100;
                SSoundMng.I.bCharLock[6] = false;
            }
            else if (SSoundMng.I.nCredit < 100)
            {
                Debug.Log("크레딧이 부족합니다.");
            }

        }
        Debug.Log(SSoundMng.I.bCharLock[6]);
    }

    public void Char7()
    {
        if (SSoundMng.I.bCharLock[7])
        {
            SSoundMng.I.nCharNum = 7;
            Debug.Log("스뼤샬");
        }
        else
        {
            if (SSoundMng.I.nCredit >= 100)
            {
                SSoundMng.I.nCredit -= 100;
                SSoundMng.I.bCharLock[7] = false;
            }
            else if (SSoundMng.I.nCredit < 100)
            {
                Debug.Log("크레딧이 부족합니다.");
            }

        }
        Debug.Log(SSoundMng.I.bCharLock[7]);
    }

}
