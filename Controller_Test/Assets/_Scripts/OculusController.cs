using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusController : MonoBehaviour {

    public const string LeftIndexTrigger_str = "Oculus_CrossPlatform_PrimaryIndexTrigger";
    public const string RightIndexTrigger_str = "Oculus_CrossPlatform_SecondaryIndexTrigger";
    public const string RightVertical_str =
                                        "Oculus_CrossPlatform_SecondaryThumbstickVertical";
    public const string RightHorizontal_str =
                                        "Oculus_CrossPlatform_SecondaryThumbstickHorizontal";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log("squeeze 1" + Input.GetAxis("Oculus_CrossPlatform_PrimaryIndexTrigger"));
        //Debug.Log("squeeze 2" + Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger"));

        Debug.Log("RightVertical_str " + Input.GetAxis(RightVertical_str));
        Debug.Log("RightHorizontal_str " + Input.GetAxis(RightHorizontal_str));

    }
}
