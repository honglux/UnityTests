using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("GetButtonDown " + Input.GetButtonDown("Fire1"));
		Debug.Log("GetMouseButton " + Input.GetMouseButton(0));
		Debug.Log("GetButtonUp " + Input.GetButtonUp("Fire1"));
    }
}
