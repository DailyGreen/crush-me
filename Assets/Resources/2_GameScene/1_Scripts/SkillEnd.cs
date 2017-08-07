using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEnd : MonoBehaviour {

    public GameObject[] Scene;


    public void Boom()
    {
        Scene[0].SetActive(false);
        Scene[1].SetActive(false);
        Scene[2].SetActive(true);
    }
    public void Desskill()
    {
        gameObject.SetActive(false);
    }

    void LazerAniEnd()
    {
        gameObject.SetActive(false);
    }

}
