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
    public GameObject CharSelectObj;

    private void Update()
    {
        if (bTitleAlpha)
            TitleSr.color -= new Color(0f, 0f, 0f, 0.1f);
    }

    public void PlayBtn()
    {
        CharSelectObj.SetActive(false);
        StartAni[0].SetTrigger("Start");
        StartAni[1].SetTrigger("Start");
        StartAni[2].enabled = true;

        bTitleAlpha = true;
    }
}
