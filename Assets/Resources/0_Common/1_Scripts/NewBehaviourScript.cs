using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour {

    public SFade asdf;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(asdf.FadeCtrl())
        {
            SceneManager.LoadScene("1_MenuScene");
            Debug.Log(asdf.FadeCtrl());
        }
    }
}
