using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerAni : MonoBehaviour
{

    public BoxCollider2D LazerBox;
    public GameObject LazerPre;
    public Animator LazerAnimator;
    public SPlayerMove HeroSc;
    LazerPre parent;


    void Start()
    {
        HeroSc = GameObject.Find("PLAYER").GetComponent<SPlayerMove>();
        parent = transform.parent.GetComponent<LazerPre>();
    }

    void Update()
    {
        // 수정해보장
        if (!SGameMng.I.bPuaseBtn)
            LazerAnimator.speed = 1f;

        else
            LazerAnimator.speed = 0f;

        if (HeroSc.bDbUse)
            transform.localPosition = new Vector3(1000f, 0f, 0f);

    }

    public void LazerAniEnd()
    {
        Debug.Log("Release");
        HeroSc.bDbUse = false;
        parent.Release();
        // Destroy(LazerPre);
    }

    public void LazerDmg()
    {
        LazerBox.enabled = true;
        SSoundMng.I.Play("Lazer", true, false);
    }

    public void LazerDmgOff()
    {
        LazerBox.enabled = false;
    }
}
