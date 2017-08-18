using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEnd : MonoBehaviour {

    public GameObject[] Scene;
    public SPlayerMove HeroSc;

    public void Boom()
    {
        Scene[0].SetActive(false);
        Scene[1].SetActive(false);
        Scene[2].SetActive(true);
    }
    public void Desskill()
    {
        HeroSc.bDbUse = false;
        gameObject.SetActive(false);
    }

    public void Shield()
    {
        HeroSc.bDmgAccess = false;
        HeroSc.ShieldGams.SetActive(false);
        HeroSc.bSkills[1] = false;
        HeroSc.bMjSkill = false;
    }

    public void Speed()
    {
        if (HeroSc.bSuSkill)
        {
            HeroSc.bSpeedSkillCheck = false;
            HeroSc.HeroFireGams[0].SetActive(true);
            HeroSc.HeroFireGams[1].SetActive(false);
            HeroSc.bSuSkill = false;
            HeroSc.bSkills[2] = false;
        }
    }
}
