using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log("squeeze 1" + Input.GetAxis("Oculus_CrossPlatform_PrimaryIndexTrigger"));
        Debug.Log("squeeze 2" + Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger"));
        


    }
}
