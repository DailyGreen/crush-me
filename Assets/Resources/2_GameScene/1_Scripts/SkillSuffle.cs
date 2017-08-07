using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSuffle : MonoBehaviour {

    public GameObject[] SkillGams;

	// Use this for initialization
	void Start () {
        Suffle();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Suffle()
    {
        for (int i = 0; i < SkillGams.Length; i++)
        {
            Vector3 temp = SkillGams[i].transform.position;
            int randomIndex = Random.Range(0, SkillGams.Length);
            SkillGams[i].transform.position = SkillGams[randomIndex].transform.position;
            SkillGams[randomIndex].transform.position = temp;
        }
    }

}
