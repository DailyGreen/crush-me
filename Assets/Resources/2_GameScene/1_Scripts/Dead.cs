using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour {

    public GameObject[] Scene;


    public void Boom()
    {
        Scene[0].SetActive(false);
        Scene[1].SetActive(false);
        Scene[2].SetActive(true);
    }

}
