using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnMng : MonoBehaviour 
{
    public void HomeBtn()
    {
        SceneManager.LoadScene("1_MenuScene");
    }

    public void RetryBtn()
    {
        SceneManager.LoadScene("2_GameScene");
    }

}
