using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    public GameObject Earth;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Earth.transform.Rotate(new Vector3(0f, 0f, -360f) * 0.2f * Time.deltaTime, Space.World);
    }

    public void GameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("2_GameScene");
    }

}
