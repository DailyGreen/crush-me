using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SPlayBtn : MonoBehaviour
{
    public Animator[] StartAni = null;
    public void PlayBtn()
    {
        StartAni[0].enabled = true;

        StartAni[1].enabled = true;
    }
}
