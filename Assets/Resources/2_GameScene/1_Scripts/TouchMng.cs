using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMng : MonoBehaviour
{
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
                        }
                    }
                    else if (!SGameMng.I.bRightTouch)
                    {
                        if (hit.transform.CompareTag("RightTouch"))
                        {
                            SGameMng.I.bRightTouch = true;
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
            }

            if (SGameMng.I.bRightTouch)
            {
                SGameMng.I.bRightTouch = false;
            }
        }
    }
}
