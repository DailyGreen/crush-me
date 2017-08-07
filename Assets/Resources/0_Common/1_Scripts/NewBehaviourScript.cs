using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public SFade asdf;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(asdf.FadeCtrl())
        {
            Application.LoadLevel("2_GameScene");
            Debug.Log(asdf.FadeCtrl());
        }
    }
}
