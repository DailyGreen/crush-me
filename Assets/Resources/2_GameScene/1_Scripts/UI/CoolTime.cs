using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTime : MonoBehaviour {

    public Text FirstSkill;
    public Text SecondSkill;
    public SPlayerMove HeroSc;
	
	// Update is called once per frame
	void Update () {
        FirstSkill.text = HeroSc.SkillCool[0].ToString();
        SecondSkill.text = HeroSc.SkillCool[1].ToString();
	}
}
