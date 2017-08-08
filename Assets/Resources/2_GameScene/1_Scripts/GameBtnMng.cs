using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameBtnMng : MonoBehaviour
{

    public GameObject PauseSceneGams;
    public GameObject RePlayCountGams;
    public GameObject ReplayLayerGams;
    public Image PauseBtnImg;
    public Text CountText;

    public void PauseBtn()
    {
        //Time.timeScale = 0;
        PauseSceneGams.SetActive(true);
        PauseBtnImg.color = new Color(255f, 255f, 255f, 0f);
        ReplayLayerGams.SetActive(true);
        SGameMng.I.bPause = true;
    }

    public void RePlayBtn()
    {
        RePlayCountGams.SetActive(true);
        StartCoroutine(Replay());
    }

    public void HomeBtn()
    {
        SceneManager.LoadScene("1_MenuScene");
        //Time.timeScale = 1;
        SSoundMng.I.Stop();
    }

    public void SoundOnBtn()
    {
        if (SSoundMng.I.bSoundOnOff)
            SSoundMng.I.Play("Game", false, true);

        SSoundMng.I.bSoundOnOff = false;
    }

    public void SoundOffBtn()
    {
        SSoundMng.I.Stop();
        SSoundMng.I.bSoundOnOff = true;
    }

    IEnumerator Replay()
    {
        //Time.timeScale = 1;
        SGameMng.I.bMoveAccess = true;
        ReplayLayerGams.SetActive(false);
        CountText.text = 3.ToString();
        CountText.fontSize = 200;
        yield return new WaitForSeconds(1f);
        CountText.text = 2.ToString();
        yield return new WaitForSeconds(1f);
        CountText.text = 1.ToString();
        yield return new WaitForSeconds(1f);
        CountText.fontSize = 100;
        CountText.text = "START!";
        yield return new WaitForSeconds(1f);
        SGameMng.I.bPause = false;
        PauseSceneGams.SetActive(false);
        RePlayCountGams.SetActive(false);
        SGameMng.I.bMoveAccess = false;
        PauseBtnImg.color = new Color(255f, 255f, 255f, 255f);
    }

}
