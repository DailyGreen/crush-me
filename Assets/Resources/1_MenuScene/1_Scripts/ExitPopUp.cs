using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPopUp : MonoBehaviour {

    Animator ExitAni;

	// Use this for initialization
	void Start () {
        ExitAni = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void ExitAniEnd()
    {
        ExitAni.enabled = false;
    }
}
