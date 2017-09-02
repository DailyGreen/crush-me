using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillBtn : MonoBehaviour
{

    public SPlayerMove HeroSc;

    public GameObject[] SkillText;

    public Image[] SkillImg;

    public bool[] bSkillUseAccess;
    public bool[] bSkillEnd;
    public bool[] bSkillSet;

    public GameObject[] SkillCoolGams;

    public Button[] SkillBtns;

    public void FirstSkill()
    {
        if (bSkillSet[0])
        {
            if (HeroSc.bCountSetCom)
            {
                SkillText[0].SetActive(true);

                SkillImg[0].color = new Color(255f, 255f, 255f, 50 / 255f);


                if (!bSkillUseAccess[0])
                {
                    StartCoroutine(SkillCount1());
                    bSkillUseAccess[0] = true;
                    bSkillEnd[0] = true;
                }

                SkillBtns[0].enabled = false;

                if (HeroSc.nSkillNum[0] == 1)
                {
                    HeroSc.bSkills[0] = true;
                }
                else if (HeroSc.nSkillNum[0] == 2)
                {
                    HeroSc.bSkills[1] = true;
                }
                else if (HeroSc.nSkillNum[0] == 3)
                {
                    HeroSc.bSkills[2] = true;
                }
                else if (HeroSc.nSkillNum[0] == 4)
                {
                    HeroSc.bSkills[3] = true;
                }
            }
        }
    }

    public void SecondSkill()
    {
        if (bSkillSet[1])
        {
            if (HeroSc.bCountSetCom)
            {
                SkillText[1].SetActive(true);

                SkillImg[1].color = new Color(255f, 255f, 255f, 50 / 255f);


                if (!bSkillUseAccess[1])
                {
                    StartCoroutine(SkillCount2());
                    bSkillUseAccess[1] = true;
                    bSkillEnd[1] = true;
                }

                SkillBtns[1].enabled = false;

                if (HeroSc.nSkillNum[1] == 1)
                {
                    HeroSc.bSkills[0] = true;
                }
                else if (HeroSc.nSkillNum[1] == 2)
                {
                    HeroSc.bSkills[1] = true;
                }
                else if (HeroSc.nSkillNum[1] == 3)
                {
                    HeroSc.bSkills[2] = true;
                }
                else if (HeroSc.nSkillNum[1] == 4)
                {
                    HeroSc.bSkills[3] = true;
                }
            }
        }
    }

    IEnumerator SkillCount1()
    {
        yield return new WaitForSeconds(1f);
        if (!SGameMng.I.bPuaseBtn)
        {
            HeroSc.SkillCool[0]--;
            if (HeroSc.SkillCool[0] == 0)
            {
                HeroSc.SkillCool[0] = HeroSc.SkillCoolBackUp[0];
                bSkillUseAccess[0] = false;
                SkillImg[0].color = new Color(255f, 255f, 255f, 200 / 255f);
                SkillBtns[0].enabled = true;
                bSkillEnd[0] = false;
                SkillCoolGams[0].SetActive(false);
            }
        }
        if (HeroSc.SkillCool[0] > 0 && bSkillEnd[0])
        {
            StartCoroutine(SkillCount1());
        }
    }
    IEnumerator SkillCount2()
    {
        yield return new WaitForSeconds(1f);
        if (!SGameMng.I.bPuaseBtn)
        {
            HeroSc.SkillCool[1]--;
            if (HeroSc.SkillCool[1] == 0)
            {
                HeroSc.SkillCool[1] = HeroSc.SkillCoolBackUp[1];
                bSkillUseAccess[1] = false;
                SkillImg[1].color = new Color(255f, 255f, 255f, 200 / 255f);
                SkillBtns[1].enabled = true;
                bSkillEnd[1] = false;
                SkillCoolGams[1].SetActive(false);
            }
        }
        if (HeroSc.SkillCool[1] > 0 && bSkillEnd[1])
        {
            StartCoroutine(SkillCount2());
        }

    }
}