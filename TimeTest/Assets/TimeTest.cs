using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Millisecond "+DateTime.Now.Millisecond);
        Debug.Log("Time.time " + Time.time*1000);
    }
}
