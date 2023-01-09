using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    public MenuBtnMng MenuBtnSc = null;
    public Earth EarthSc = null;

    public GameObject CharSelectGams = null;

    public Image[] JoyStickPosImg = null;

    public SpriteRenderer RocketSr = null;

    public bool bCharSelectOn = false;

    public TMPro.TextMeshProUGUI CreditText;
    public CharSelect CharSelectSc;

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
        switch(SSoundMng.I.nCharNum)
        {
            case 0:
                CharSelectSc.SelectFrame(SSoundMng.I.nCharNum, 0);
                break;
            case 2:
                CharSelectSc.SelectFrame(SSoundMng.I.nCharNum, 2);
                break;
            case 8:
                CharSelectSc.SelectFrame(SSoundMng.I.nCharNum, 3);
                break;
            default:
                CharSelectSc.SelectFrame(SSoundMng.I.nCharNum, 1);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CreditText.text = "$ " + SSoundMng.I.credit.ToString();
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