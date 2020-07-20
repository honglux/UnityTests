using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class Test1 : MonoBehaviour
{
    private InputDevice device;
    public Vector3 HS;
    public Vector3 HS2;
    public Vector3 HAC;
    public Vector3 HP;
    public XRInputSubsystem XRISS;
    public float RightC_trigger;
    public bool RightC_YButton;
    public bool RightC_YButton2;
    public Vector2 RightC_axis;

    private void Awake()
    {
        this.device = new InputDevice();
        this.HS = new Vector3();
        this.HS2 = new Vector3();
        this.HAC = new Vector3();
        this.HP = new Vector3();
        this.XRISS = null;
        this.RightC_trigger = 0.0f;
        this.RightC_axis = new Vector2();
    }

    // Start is called before the first frame update
    void Start()
    {
        //test1();
        //test3();
        //test2();
        //test5();
        test7();
    }

    // Update is called once per frame
    void Update()
    {
        //test4();
        //test6();
        test8();
    }

    private void test1()
    {
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);

        foreach (var device in inputDevices)
        {
            Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.role.ToString()));
        }
    }

    private void test3()
    {
        var headD = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.Head, headD);

        if (headD.Count == 1)
        {
            UnityEngine.XR.InputDevice device = headD[0];
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", device.name, device.characteristics.ToString()));
        }
        else if (headD.Count > 1)
        {
            Debug.Log("Found more than one left hand!");
        }
    }

    private void test2()
    {
        var headD = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.Head, headD);
        device = headD[0];
    }

    private void test4()
    {
        device.TryGetFeatureValue(CommonUsages.centerEyePosition, out HP);
        device.TryGetFeatureValue(CommonUsages.centerEyeAngularVelocity, out HS);
        device.TryGetFeatureValue(CommonUsages.centerEyeAngularAcceleration, out HAC);
    }

    private void test5()
    {
        List<XRInputSubsystem> XISs = new List<XRInputSubsystem>();
        SubsystemManager.GetInstances<XRInputSubsystem>(XISs);
        for (int i = 0; i < XISs.Count; i++)
        {
            Debug.Log(XISs[i].SubsystemDescriptor.ToString());
        }
        XRISS = XISs[0];
    }

    private void test6()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            XRISS.TryRecenter();
        }
    }
    
    private void test7()
    {
        XRDeviceManager.InitXRDevice();
    }

    private void test8()
    {
        XRDeviceManager.HeadNode.TryGetFeatureValue(CommonUsages.deviceAngularVelocity, out HS);
        HS2 =
            (OVRPlugin.GetNodeAngularVelocity(OVRPlugin.Node.Head, OVRPlugin.Step.Render).
            FromFlippedZVector3f()) * Mathf.Rad2Deg;
        Debug.Log("!!! " + HS2.ToString("F2"));
        //XRDeviceManager.HeadNode.TryGetFeatureValue(CommonUsages.centerEyeAngularVelocity, out HS);
        XRDeviceManager.RightControllerNode.TryGetFeatureValue(CommonUsages.trigger, out RightC_trigger);
        RightC_YButton = XRDeviceManager.get_ybutton(XRNode.RightHand);
        InputHelpers.IsPressed(XRDeviceManager.get_device(XRNode.RightHand), 
            InputHelpers.Button.SecondaryButton, out RightC_YButton2);
        XRDeviceManager.RightControllerNode.TryGetFeatureValue(CommonUsages.primary2DAxis, out RightC_axis);
    }
}
