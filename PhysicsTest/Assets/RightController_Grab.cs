using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightController_Grab : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        transform.localPosition =
                OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        transform.localRotation =
                        OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
    }
}
