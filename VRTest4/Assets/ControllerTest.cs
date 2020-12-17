using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System;

public class ControllerTest : MonoBehaviour
{
    public static InputDevice RightControllerNode { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        RightControllerNode = Init_device(XRNode.RightHand);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("!!!!!" + Get_trigger(RightControllerNode).ToString("F2"));
    }

    private static InputDevice Init_device(UnityEngine.XR.XRNode node)
    {
        var devices = new List<UnityEngine.XR.InputDevice>();
        try { UnityEngine.XR.InputDevices.GetDevicesAtXRNode(node, devices); }
        catch (Exception e) { Debug.LogError("GetDevicesAtXRNode Error! " + e); }


        if (devices.Count == 1)
        {
            Debug.Log(string.Format("Device name '{0}' with role '{1}'",
                devices[0].name, devices[0].characteristics.ToString()));
            return devices[0];
        }
        else if (devices.Count > 1)
        {
            Debug.LogError(string.Format("Found more than one node from '{0}'!", node.ToString()));
        }
        return new InputDevice();
    }

    public static float Get_trigger(InputDevice device)
    {
        float trigger = 0.0f;
        device.TryGetFeatureValue(CommonUsages.trigger, out trigger);
        bool button = false;
        device.TryGetFeatureValue(CommonUsages.primaryButton, out button);
        Debug.Log("@@@@@@@" + button);
        return trigger;
    }
}
