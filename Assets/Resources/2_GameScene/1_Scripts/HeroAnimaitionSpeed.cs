using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimaitionSpeed : MonoBehaviour {

     Animator SkillAni;

	void Start () {
        SkillAni = GetComponent<Animator>();
	}
	
	void Update () {
        if (!SGameMng.I.bPuaseBtn)
            SkillAni.speed = 1f;

        else
            SkillAni.speed = 0f;
	}
}
