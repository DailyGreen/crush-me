using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour {

    public Animation EarthAni;

	// Use this for initialization
	void Start () {
        EarthAni.Stop();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.CompareTag("Earth"))
                {
                    EarthAni.Play();
                }

            }
        }

    }

}
