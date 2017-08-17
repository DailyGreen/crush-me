using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerAni : MonoBehaviour {

    public BoxCollider2D LazerBox;
    public GameObject LazerPre;

    public void LazerAniEnd()
    {
        Destroy(LazerPre);
    }

    public void LazerDmg()
    {
        LazerBox.enabled = true;
    }

    public void LazerDmgOff()
    {
        LazerBox.enabled = false;
    }
}
