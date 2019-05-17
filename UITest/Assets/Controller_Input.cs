using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Input : MonoBehaviour {

    public OVRInput.Controller Controller_type;

    [SerializeField] private ControllerSystemActions MiddleFingerAction;
    [SerializeField] private ControllerSystemActions IndexFingerAction;

    public System.Action UISystemDown { get; set; }
    public System.Action UISystemUp { get; set; }
    public System.Action ShootDown { get; set; }
    public System.Action ShootUp { get; set; }
    public bool Forward_flag { get; set; }
    public bool Grab_falg { get; set; }
    public bool Left_flag { get; set; }
    public bool Right_flag { get; set; }

    private bool UISystem_down_flag;
    private bool shoot_down_flag;

    private void Awake()
    {
        this.UISystemDown = null;
        this.UISystemUp = null;
        this.ShootDown = null;
        this.ShootUp = null;
    }

    // Use this for initialization
    void Start () {
        this.Forward_flag = false;
        this.Grab_falg = false;
        this.Left_flag = false;
        this.Right_flag = false;
        this.UISystem_down_flag = false;
        this.shoot_down_flag = false;
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

                    if (Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger") > 0.5f)
                    {
                        //Debug.Log("Index");
                        switch (IndexFingerAction)
                        {
                            case ControllerSystemActions.Empty:
                                return;
                            case ControllerSystemActions.Shoot:
                                if(!shoot_down_flag && ShootDown != null)
                                {
                                    ShootDown();
                                    shoot_down_flag = true;
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (IndexFingerAction)
                        {
                            case ControllerSystemActions.Empty:
                                return;
                            case ControllerSystemActions.Shoot:
                                if (shoot_down_flag && ShootUp != null)
                                {
                                    ShootUp();
                                    shoot_down_flag = false;
                                }
                                break;
                        }
                    }

                    if (Input.GetAxis("Oculus_CrossPlatform_SecondaryHandTrigger") > 0.5f)
                    {
                        switch(MiddleFingerAction)
                        {
                            case ControllerSystemActions.Grab:
                                Grab_falg = true;
                                break;
                            case ControllerSystemActions.UISystem:
                                //Debug.Log("UISystemDown null "+ UISystemDown == null);
                                if(!UISystem_down_flag && UISystemDown != null)
                                {
                                    //Debug.Log("UISystemDown null " + UISystemDown == null);
                                    UISystemDown();
                                    UISystem_down_flag = true;
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (MiddleFingerAction)
                        {
                            case ControllerSystemActions.Grab:
                                Grab_falg = false;
                                break;
                            case ControllerSystemActions.UISystem:
                                if (UISystem_down_flag && UISystemDown != null)
                                {
                                    UISystemUp();
                                    UISystem_down_flag = false;
                                }
                                break;
                        }
                    }

                    break;
                }
        }

    }
}

public enum ControllerSystemActions { Empty, Grab, UISystem, Shoot };