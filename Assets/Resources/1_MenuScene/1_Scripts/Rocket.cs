using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    public GameObject[] SoundOnOffGams = null;
    public GameObject Earth = null;

    public Image[] JoyStickPosImg = null;

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
                if (hit.transform.CompareTag("Char"))
                {
                    Debug.Log("캐릭터 선택 팝업 띄우기.");
                }
            }
        }
    }

    public void GameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("2_GameScene");
    }
}