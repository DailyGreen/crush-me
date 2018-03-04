using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    public GameObject CharSelectGams = null;
    public GameObject CharSelectCloseBtn = null;
    public GameObject[] SoundOnOffGams = null;
    public GameObject Earth = null;

    public Image[] JoyStickPosImg = null;

    public SpriteRenderer RocketSr = null;

    public Sprite[] CharSprite = null;

    public bool bCharSelectOn = false;

    // Use this for initialization
    void Start()
    {
        if (!SSoundMng.I.bSoundOnOff)
        {
            SSoundMng.I.Play("Main", false, true);
            SoundOnOffGams[0].SetActive(true);
            SoundOnOffGams[1].SetActive(false);
        }

        else
        {
            SSoundMng.I.Stop();
            SoundOnOffGams[0].SetActive(false);
            SoundOnOffGams[1].SetActive(true);
        }

        if (!SSoundMng.I.bJoyPos)
        {
            JoyStickPosImg[0].color = new Color(255f, 255f, 255f, 255f);
            JoyStickPosImg[1].color = new Color(255f, 255f, 255f, 100 / 255f);
        }
        else
        {
            JoyStickPosImg[0].color = new Color(255f, 255f, 255f, 100 / 255f);
            JoyStickPosImg[1].color = new Color(255f, 255f, 255f, 255f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Earth.transform.Rotate(new Vector3(0f, 0f, -360f) * 0.2f * Time.deltaTime, Space.World);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.CompareTag("Char") && !bCharSelectOn)
                {
                    Debug.Log("캐릭터 선택 팝업 띄우기.");
                    CharSelectGams.SetActive(true);
                    CharSelectCloseBtn.SetActive(true);
                    bCharSelectOn = true;
                }
            }
        }

        CharSelect();
    }

    void CharSelect()
    {
        if (SSoundMng.I.nCharNum == 0)
        {
            RocketSr.sprite = CharSprite[0];
            RocketSr.color = new Color(255f, 255f, 255f, 255f);
        }
        else if (SSoundMng.I.nCharNum == 1)
        {
            RocketSr.sprite = CharSprite[1];
            RocketSr.color = new Color(255f, 255f, 255f, 255f);
        }
        else if (SSoundMng.I.nCharNum == 2)
        {
            RocketSr.sprite = CharSprite[0];
            RocketSr.color = new Color(210f, 68f, 68f, 255f);
        }
        else if (SSoundMng.I.nCharNum == 3)
        {
            RocketSr.sprite = CharSprite[0];
            RocketSr.color = new Color(84f, 105f, 248f, 255f);
        }
        else if (SSoundMng.I.nCharNum == 4)
        {
            RocketSr.sprite = CharSprite[0];
            RocketSr.color = new Color(230f, 233f, 56f, 255f);
        }
        else if (SSoundMng.I.nCharNum == 5)
        {
            RocketSr.sprite = CharSprite[0];
            RocketSr.color = new Color(62f, 220f, 227f, 255f);
        }
        else if (SSoundMng.I.nCharNum == 6)
        {
            RocketSr.sprite = CharSprite[0];
            RocketSr.color = new Color(169f, 169f, 169f, 255f);
        }
        else if (SSoundMng.I.nCharNum == 7)
        {
            RocketSr.sprite = CharSprite[2];
            RocketSr.color = new Color(255f, 255f, 255f, 255f);
        }
    }

    public void GameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("2_GameScene");
    }
}