using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SPlayBtn : MonoBehaviour
{
    public Animator[] StartAni = null;

    public GameObject TitleGams = null;

    public SpriteRenderer TitleSr = null;

    public bool bTitleAlpha = false;
    public GameObject gameObjectObj;

    private void Update()
    {
        if (bTitleAlpha)
            TitleSr.color -= new Color(0f, 0f, 0f, 0.1f);
    }

    public void PlayBtn()
    {
        gameObjectObj.SetActive(false);
        StartAni[0].SetTrigger("Start");
        for (int i = 0; i < StartAni.Length; i++)
        {
            if(i != 0)
                StartAni[i].enabled = true;
        }

        bTitleAlpha = true;
    }
}
