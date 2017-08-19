using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFade : MonoBehaviour
{
    public enum E_FADE
    {
        E_FADE_IN = 0,
        E_FADE_OUT,
    }

    public E_FADE ValueEnum;

    public Image FadeImage;

    public bool FadeCtrl()       // 밝아지는거
    {
        if ((int)ValueEnum == 0)
        {
            if (FadeImage.color.a > 0f)
            {
                FadeImage.color -= new Color(0, 0, 0, 0.01f);
            }
            else
            {
                return true;
            }
        }

        else if ((int)ValueEnum == 1)
        {
            if (FadeImage.color.a < 1f)
            {
                FadeImage.color += new Color(0, 0, 0, 0.01f);
            }
            else
            {
                return true;
            }
        }

        return false;
    }
}