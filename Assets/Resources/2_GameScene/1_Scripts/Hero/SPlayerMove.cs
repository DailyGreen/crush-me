﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SPlayerMove : MonoBehaviour
{
    public SkillBtn SkillBtnSc = null;

    public Transform PlayerParentTr = null;

    public GameObject SkillsGams = null;
    public GameObject[] HeroFireGams = null;
    public GameObject ShieldGams = null;
    public GameObject DestroySkill = null;
    public GameObject DieGams = null;
    public GameObject Explaying = null;
    public GameObject BackGround = null;

    public Image[] HaveSKillImg = null;

    public Sprite[] SkillSpr = null;
    public Sprite[] CharSprite = null;

    public SpriteRenderer[] HeroFireSr = null;
    SpriteRenderer Sr = null;

    public CapsuleCollider2D Ccol2d = null;

    public Color CharColor = new Color(225f, 255f, 255f, 255f);

    bool bBdSkill = false;
    public bool bSuSkill = false;
    public bool bMjSkill = false;
    bool bBsSkill = false;
    [SerializeField]
    bool bHeroDie = false;
    bool bSkillSet = false;
    bool bDesCool = false;
    public bool bSpeedSkillCheck = false;
    public bool bDmgAccess = false;
    public bool bTimeCorutinStart = false;
    public bool bBdSkillUse = false;
    public bool bCountSetCom;
    public bool[] bSkills;
    public bool bDbUse = false;

    float fBdSkillTime;
    float fSuSkill;
    float fMjSkill;
    float fBsSkillCt;
    public float fSpeed;

    public int nSkillCount = 2;
    public int[] nSkillNum;
    public int[] SkillCool = new int[2];
    public int[] SkillCoolBackUp = new int[2];

    [SerializeField]
    Hero.HeroMover heroScrp;

    public GameObject[] itemPrefab;

    //////////////////////////////////////////////////////////////////화면 크기 가로2.5 세로4.5////////////////////////////////////////////////////////////////////////

    void Start()
    {
        Sr = GetComponent<SpriteRenderer>();
        CharSelect();
    }

    void Update()
    {
        if (!SGameMng.I.bPause && !SGameMng.I.bMoveAccess)
        {
            TimeCount();
            if (bSkills[0])
            {
                DestroyBullet();
            }
            if (bSkills[1])
            {
                Mujuck();
            }
            if (bSkills[2])
            {
                SpeedUp();
            }
            if (bSkills[3])
            {
                BulletSmall();
            }
        }

        if (nSkillCount.Equals(0) || SGameMng.I.bStartCheck)
        {
            SkillsGams.SetActive(false);

            Explaying.SetActive(false);
        }
        if (!bDesCool)
        {
            DestroySkill.transform.localPosition = Vector3.zero;
        }
        SKillCoolSet();


    }

    void TimeCount()
    {
        if (!bHeroDie && SGameMng.I.bStartCheck && !bTimeCorutinStart)
        {
            StartCoroutine(TimeCountCor());
            bTimeCorutinStart = true;
        }
    }

    IEnumerator TimeCountCor()
    {
        yield return new WaitForSeconds(1f);
        if (!SGameMng.I.bPause)
        {
            SGameMng.I.nTimeCount++;
            if (!bHeroDie)
                SSoundMng.I.credit++;
        }
        StartCoroutine(TimeCountCor());
    }

    public void DestroyBullet()
    {

        if (!bBdSkill)
        {
            if (!bBdSkill)
            {
                for (int i = 0; i < REnemyMove.v_bullet.Count; i++)
                {
                    if (REnemyMove.v_bullet[i].isColliding)
                    {
                        REnemyMove.v_bullet[i].Sr.color = new Color(255f, 255f, 255f, 0f);
                        REnemyMove.v_bullet[i].bBulletCol = true;
                    }
                }
                bBdSkill = true;
                bBdSkillUse = true;
                fBdSkillTime = Time.time;
                DestroySkill.transform.parent = BackGround.transform;
                DestroySkill.SetActive(true);
                bDesCool = true;
                bDbUse = true;
            }
            SSoundMng.I.Play("Red_Skill", true, false);
        }
        if (bBdSkill)
        {
            if (Time.time > fBdSkillTime + 1f)                     //쿨타임 10초
            {
                bBdSkill = false;
                bSkills[0] = false;
                DestroySkill.transform.parent = transform;
                bDesCool = false;
            }
        }

        if (bBdSkillUse)
            bBdSkillUse = false;
    }

    public void Mujuck()
    {
        if (!bMjSkill)
        {

            bMjSkill = true;
            fMjSkill = Time.time;
            if (!bHeroDie)
            {
                ShieldGams.SetActive(true);
            }

            SSoundMng.I.Play("Shield", true, false);
        }

        if (bMjSkill)                                                       //2초간 무적
        {
            bDmgAccess = true;
        }
    }

    public void SpeedUp()
    {
        if (!bSuSkill)
        {

            bSpeedSkillCheck = true;
            bSuSkill = true;
            fSuSkill = Time.time;
            heroScrp._moveSpeed = 6f;
            if (!bHeroDie)
            {
                HeroFireGams[0].SetActive(false);
                HeroFireGams[1].SetActive(true);
            }
            SSoundMng.I.Play("SpeedUp", true, false);
        }
    }

    public void BulletSmall()
    {
        if (!bBsSkill)
        {
            for (int i = 0; i < REnemyMove.v_bullet.Count; i++)
            {
                if (REnemyMove.v_bullet[i].isColliding)
                    REnemyMove.v_bullet[i].transform.localScale = new Vector2(0.5f, 0.5f);
            }
            bBsSkill = true;

            fBsSkillCt = Time.time;
            bSkills[3] = false;
            SSoundMng.I.Play("Magic", true, false);
        }

        if (bBsSkill)
        {
            if (Time.time > fBsSkillCt + 1f)                                //총알 크기 줄이기 쿨타임 15초
            {
                bBsSkill = false;
            }
        }
    }

    IEnumerator SkillCount()
    {
        yield return new WaitForSeconds(0.001f);
        bSkillSet = false;
    }

    void SKillCoolSet()
    {
        if (!bCountSetCom)
        {
            switch (nSkillNum[0])
            {
                case 1:
                    SkillCool[0] = 10;
                    SkillCoolBackUp[0] = 10;
                    break;
                case 2:
                    SkillCool[0] = 7;
                    SkillCoolBackUp[0] = 7;
                    break;
                case 3:
                    SkillCool[0] = 8;
                    SkillCoolBackUp[0] = 8;
                    break;
                case 4:
                    SkillCool[0] = 15;
                    SkillCoolBackUp[0] = 15;
                    break;
            }

            switch (nSkillNum[1])
            {
                case 1:
                    SkillCool[1] = 10;
                    SkillCoolBackUp[1] = 10;
                    bCountSetCom = true;
                    break;
                case 2:
                    SkillCool[1] = 7;
                    SkillCoolBackUp[1] = 7;
                    bCountSetCom = true;
                    break;
                case 3:
                    SkillCool[1] = 8;
                    SkillCoolBackUp[1] = 8;
                    bCountSetCom = true;
                    break;
                case 4:
                    SkillCool[1] = 15;
                    SkillCoolBackUp[1] = 15;
                    bCountSetCom = true;
                    break;
            }

        }
    }

    public void UseItem(int kind)
    {
        switch(kind)
        {
            case 0:
                Instantiate(itemPrefab[0], transform.position, Quaternion.identity, transform.parent.parent);
                break;
        }
    }

    void CharSelect()
    {
        switch(SSoundMng.I.nCharNum)
        {
            case 0:
                Sr.sprite = CharSprite[0];
                CharColor = new Color(255f, 255f, 255f, 255f);
                Sr.color = CharColor;
                break;
            case 1:
                Sr.sprite = CharSprite[1];
                CharColor = new Color(255f, 255f, 255f, 255f);
                Sr.color = CharColor;
                break;
            case 2:
                Sr.sprite = CharSprite[2];
                CharColor = new Color(255f, 255f, 255f, 255f);
                Sr.color = CharColor;
                break;
            case 3:
                Sr.sprite = CharSprite[1];
                CharColor = new Color(210 / 255f, 68 / 255f, 68 / 255f, 255f);
                Sr.color = CharColor;
                break;
            case 4:
                Sr.sprite = CharSprite[1];
                CharColor = new Color(84 / 255f, 105 / 255f, 248 / 255f, 255f);
                Sr.color = CharColor;
                break;
            case 5:
                Sr.sprite = CharSprite[1];
                CharColor = new Color(230 / 255f, 233 / 255f, 56 / 255f, 255f);
                Sr.color = CharColor;
                break;
            case 6:
                Sr.sprite = CharSprite[1];
                CharColor = new Color(62 / 255f, 220 / 255f, 227 / 255f, 255f);
                Sr.color = CharColor;
                break;
            case 7:
                Sr.sprite = CharSprite[1];
                CharColor = new Color(169 / 255f, 169 / 255f, 169 / 255f, 255f);
                Sr.color = CharColor;
                break;
            case 8:
                Sr.sprite = CharSprite[3];
                CharColor = new Color(255f, 255f, 255f, 255f);
                Sr.color = CharColor;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!bDmgAccess)
        {
            if (col.CompareTag("Bullet") || col.CompareTag("Lazer"))
            {
                bHeroDie = true;
                Sr.enabled = false;
                HeroFireSr[0].enabled = false;
                HeroFireSr[1].enabled = false;
                Ccol2d.enabled = false;
                DieGams.transform.parent = BackGround.transform;
                DieGams.SetActive(true);
                SSoundMng.I.Play("Boom", true, false);
            }
        }

        if (nSkillCount.Equals(2) && !bSkillSet)
        {
            for (int i = 0; i < 4; i++)
            {
                if (col.CompareTag(("Skill" + i.ToString())))
                {
                    HaveSKillImg[0].sprite = SkillSpr[i];
                    bSkillSet = true;
                    nSkillNum[0] = i + 1;
                    nSkillCount--;
                    SkillBtnSc.bSkillSet[0] = true;
                    StartCoroutine(SkillCount());
                }
            }
        }
        if (nSkillCount.Equals(1) && !bSkillSet)
        {
            for (int i = 0; i < 4; i++)
            {
                if (col.CompareTag(("Skill" + i.ToString())))
                {
                    HaveSKillImg[1].sprite = SkillSpr[i];
                    bSkillSet = true;
                    nSkillNum[1] = i + 1;
                    SkillBtnSc.bSkillSet[1] = true;
                    nSkillCount--;
                }
            }
        }
    }
}