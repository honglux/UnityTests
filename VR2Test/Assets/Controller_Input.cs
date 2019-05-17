using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Input : MonoBehaviour {

    //public enum ControllerType { LeftController,RightController}

    public OVRInput.Controller Controller_type;

    public bool Forward_flag { get; set; }
    public bool Grab_falg { get; set; }
    public bool Left_flag { get; set; }
    public bool Right_flag { get; set; }



    // Use this for initialization
    void Start () {
        this.Forward_flag = false;
        this.Grab_falg = false;
        this.Left_flag = false;
        this.Right_flag = false;
	}
	
	// Update is called once per frame
	void Update () {

        switch(Controller_type)
        {
            case OVRInput.Controller.LTouch:
                {
                    //if (Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") 
                    //                                                                > 0.5f)
                    //{
                    //    Forward_flag = true;
                    //}
                    //else
                    //{
                    //    Forward_flag = false;
                    //}

                    if (Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger") > 0.5f)
                    {
                        Debug.Log("Grabing1111!!!");
                        Grab_falg = true;
                    }
                    else
                    {
                        Grab_falg = false;
                    }
                    if (Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal")
                                                                < -0.5f)
                    {
                        Left_flag = true;
                        Right_flag = false;
                    }
                    else if (Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal")
                                                                    > -0.5f &&
                            Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal")
                                                                    < 0.5f)
                    {
                        Left_flag = false;
                        Right_flag = false;
                    }
                    else if (Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal")
                                            > 0.5f)
                    {
                        Left_flag = false;
                        Right_flag = true;
                    }

                    break;
                }
            case OVRInput.Controller.RTouch:
                {
                    if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical")
                                                                                    > 0.5f)
                    {
                        Forward_flag = true;
                    }
                    else
                    {
                        Forward_flag = false;
                    }

                    if (Input.GetAxis("Oculus_CrossPlatform_SecondaryHandTrigger") > 0.5f)
                    {
                        Debug.Log("Grabing2222~~~~");
                        Grab_falg = true;
                    }
                    else
                    {
                        Grab_falg = false;
                    }

                    break;
                }
        }

    }
}
