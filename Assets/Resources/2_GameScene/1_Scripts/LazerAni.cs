using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerAni : MonoBehaviour {

    public BoxCollider2D LazerBox;
    public Lazer LazerSc;

    public void LazerAniEnd()
    {
        LazerSc.bLazerUsed = false;
        gameObject.SetActive(false);
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
