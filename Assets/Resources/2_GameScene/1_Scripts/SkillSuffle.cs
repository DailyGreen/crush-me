using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSuffle : MonoBehaviour {

    public GameObject[] SkillGams = null;

	void Start () {
        Suffle();
	}

    void Suffle()
    {
        for (int i = 0; i < SkillGams.Length; i++)
        {
            Vector3 SkillPos = SkillGams[i].transform.position;
            int RandomIndex = Random.Range(0, SkillGams.Length);
            SkillGams[i].transform.position = SkillGams[RandomIndex].transform.position;
            SkillGams[RandomIndex].transform.position = SkillPos;
        }
    }

}
