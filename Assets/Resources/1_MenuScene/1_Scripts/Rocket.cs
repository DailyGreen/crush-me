using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    public MenuBtnMng MenuBtnSc = null;
    public Earth EarthSc = null;

    public GameObject CharSelectGams = null;
    //public GameObject CharSelectCloseBtn = null;
    //public GameObject CharFrameGams = null;
    //public GameObject[] CharBtnGams = null;

    public Image[] JoyStickPosImg = null;

    public SpriteRenderer RocketSr = null;

    public bool bCharSelectOn = false;

    // Use this for initialization
    void Start()
    {
        SSoundMng.I.Play("Main", false, true);

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

        SSoundMng.I.nAC = 1000;
        Debug.Log("현재 크레딧 1000으로 강제 조정중");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.CompareTag("Char") && !bCharSelectOn)
                {
                    CharSelectGams.SetActive(true);
                    bCharSelectOn = true;
                    MenuBtnSc.bExit = true;
                    EarthSc.bEarthTouchAccess = true;
                }
            }
        }
    }

    public void GameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("2_GameScene");
    }
}