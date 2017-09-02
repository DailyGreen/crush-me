using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMng : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!SGameMng.I.bPuaseBtn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (!SGameMng.I.bLeftTouch)
                    {
                        if (hit.transform.CompareTag("LeftTouch"))
                        {
                            SGameMng.I.bLeftTouch = true;
                            Debug.Log("LeftTouchOn");
                        }
                    }
                    if (!SGameMng.I.bRightTouch)
                    {
                        if (hit.transform.CompareTag("RightTouch"))
                        {
                            SGameMng.I.bRightTouch = true;
                            Debug.Log("RightTouchOn");
                        }
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (SGameMng.I.bLeftTouch)
            {
                SGameMng.I.bLeftTouch = false;
                Debug.Log("LeftTouchOff");
            }

            if (SGameMng.I.bRightTouch)
            {
                SGameMng.I.bRightTouch = false;
                Debug.Log("RightTouchOff");
            }
        }

    }
}
