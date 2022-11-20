using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LazerPre : MonoBehaviour
{
    public float[] fPosValue;

    IObjectPool<LazerPre> laserPool;

    public void Release()
    {
        laserPool.Release(this);   
    }

    public void setPool(IObjectPool<LazerPre> pool)
    {
        laserPool = pool;
    }

    public void LazerPosSet()
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
            fPosValue[1] = Random.Range(-2f, 2f);
        }
    }

    public void LazerComeOut()
    {
        this.transform.localPosition = new Vector3(fPosValue[0], fPosValue[1], 0f);
        this.transform.localEulerAngles = new Vector3(0f, 0f, fPosValue[2]);
        this.gameObject.SetActive(true);
    }
}
