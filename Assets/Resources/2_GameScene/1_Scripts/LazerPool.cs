using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LazerPool : MonoBehaviour
{
    [SerializeField] LazerPre LaserPrefab;

    public IObjectPool<LazerPre> LaserPool;
    void Start()
    {
        LaserPool = new ObjectPool<LazerPre>(OnInit, OnObject, OnRelease, OnDestroyLaser, maxSize: 5);
        // StartCoroutine("LazerIns");
    }

    public LazerPre OnInit()
    {
        LazerPre obj = Instantiate(LaserPrefab);
        obj.transform.parent = this.transform;
        obj.setPool(LaserPool);
        return obj;
    }

    public void OnObject(LazerPre obj)
    {
       obj.LazerPosSet();
       obj.LazerComeOut();
    }

    public void OnRelease(LazerPre obj)
    {
        obj.gameObject.SetActive(false);
    }

    void OnDestroyLaser(LazerPre obj)
    {
        Destroy(obj.gameObject);
    }

    public IEnumerator LazerIns()
    {
        yield return new WaitForSeconds(.1f);
        if (!SGameMng.I.bPuaseBtn)
            LaserPool.Get();

        StartCoroutine(LazerIns());
    }

}