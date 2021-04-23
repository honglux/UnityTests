using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulator2 : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawLine(ray.origin, (ray.origin + ray.direction * 100.0f), Color.blue);

        RaycastHit[] temphits = Physics.RaycastAll(ray);

        Debug.Log("temphits " + temphits.Length);
        foreach(RaycastHit hit in temphits)
        {
            Debug.Log("hit "+hit.transform.name);
        }

    }
}
