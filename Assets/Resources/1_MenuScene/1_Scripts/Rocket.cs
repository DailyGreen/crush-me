using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    public MenuBtnMng MenuBtnSc = null;

    public GameObject CharSelectGams = null;
    public GameObject CharSelectCloseBtn = null;
    public GameObject[] SoundOnOffGams = null;
    public GameObject Earth = null;
    public GameObject CharFrameGams = null;
    public GameObject[] CharBtnGams = null;

    public Image[] JoyStickPosImg = null;

    public SpriteRenderer RocketSr = null;

    public Sprite[] CharSprite = null;

    public Color CharColor = new Color(255f, 255f, 255f, 255f);

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
                    CharSelectGams.SetActive(true);
                    CharSelectCloseBtn.SetActive(true);
                    bCharSelectOn = true;
                    MenuBtnSc.bExit = true;
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
            CharColor = new Color(255f, 255f, 255f, 255f);
            RocketSr.color = CharColor;
            CharFrameGams.transform.parent = CharBtnGams[0].transform;
            CharFrameGams.transform.localPosition = Vector3.zero;
        }
        else if (SSoundMng.I.nCharNum == 1)
        {
            RocketSr.sprite = CharSprite[1];
            CharColor = new Color(255f, 255f, 255f, 255f);
            RocketSr.color = CharColor;
            CharFrameGams.transform.parent = CharBtnGams[1].transform;
            CharFrameGams.transform.localPosition = Vector3.zero;
        }
        else if (SSoundMng.I.nCharNum == 2)
        {
            RocketSr.sprite = CharSprite[0];
            CharColor = new Color(210 / 255f, 68 / 255f, 68 / 255f, 255f);
            RocketSr.color = CharColor;
            CharFrameGams.transform.parent = CharBtnGams[2].transform;
            CharFrameGams.transform.localPosition = Vector3.zero;
        }
        else if (SSoundMng.I.nCharNum == 3)
        {
            RocketSr.sprite = CharSprite[0];
            CharColor = new Color(84 / 255f, 105 / 255f, 248 / 255f, 255f);
            RocketSr.color = CharColor;
            CharFrameGams.transform.parent = CharBtnGams[3].transform;
            CharFrameGams.transform.localPosition = Vector3.zero;
        }
        else if (SSoundMng.I.nCharNum == 4)
        {
            RocketSr.sprite = CharSprite[0];
            CharColor = new Color(230 / 255f, 233 / 255f, 56 / 255f, 255f);
            RocketSr.color = CharColor;
            CharFrameGams.transform.parent = CharBtnGams[4].transform;
            CharFrameGams.transform.localPosition = Vector3.zero;
        }
        else if (SSoundMng.I.nCharNum == 5)
        {
            RocketSr.sprite = CharSprite[0];
            CharColor = new Color(62 / 255f, 220 / 255f, 227 / 255f, 255f);
            RocketSr.color = CharColor;
            CharFrameGams.transform.parent = CharBtnGams[5].transform;
            CharFrameGams.transform.localPosition = Vector3.zero;
        }
        else if (SSoundMng.I.nCharNum == 6)
        {
            RocketSr.sprite = CharSprite[0];
            CharColor = new Color(169 / 255f, 169 / 255f, 169 / 255f, 255f);
            RocketSr.color = CharColor;
            CharFrameGams.transform.parent = CharBtnGams[6].transform;
            CharFrameGams.transform.localPosition = Vector3.zero;
        }
        else if (SSoundMng.I.nCharNum == 7)
        {
            RocketSr.sprite = CharSprite[2];
            CharColor = new Color(255f, 255f, 255f, 255f);
            RocketSr.color = CharColor;
            CharFrameGams.transform.parent = CharBtnGams[7].transform;
            CharFrameGams.transform.localPosition = Vector3.zero;
        }
    }

    public void GameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("2_GameScene");
    }
}