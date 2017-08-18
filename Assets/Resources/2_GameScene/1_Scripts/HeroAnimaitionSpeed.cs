using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimaitionSpeed : MonoBehaviour {

     Animator SkillAni;

	// Use this for initialization
	void Start () {
        SkillAni = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!SGameMng.I.bPuaseBtn)
            SkillAni.speed = 1f;

        if (SGameMng.I.bPuaseBtn)
            SkillAni.speed = 0f;
	}
}
