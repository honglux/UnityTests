using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRTest1 : MonoBehaviour
{
    [SerializeField] private TextMesh TM;

    // Start is called before the first frame update
    void Start()
    {
        XRDeviceManager.InitXRDevice();
    }

    // Update is called once per frame
    void Update()
    {
        //test1();
        test2();
        center();
    }

    private void center()
    {
        if(Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            XRDeviceManager.UpdateXRDevice();
            XRDeviceManager.recenter();
        }
        
    }

    private void test1()
    {
        Vector3 angularVelocityRead =
            (OVRPlugin.GetNodeAngularVelocity(OVRPlugin.Node.Head, OVRPlugin.Step.Render).
            FromFlippedZVector3f()) * Mathf.Rad2Deg;
        Vector3 AV2 = new Vector3();
        XRDeviceManager.get_device(XRNode.Head).TryGetFeatureValue(CommonUsages.deviceAngularVelocity, out AV2);
        AV2 *= Mathf.Rad2Deg;
        TM.text = angularVelocityRead.ToString("F2") + "\t|" + AV2.ToString("F2");
        Debug.Log("1| " + angularVelocityRead.ToString("F2") + " |2| " + AV2.ToString("F2"));
    }

    private void test2()
    {
        Quaternion quatf_orientation =
                OVRPlugin.GetNodePose(OVRPlugin.Node.EyeCenter, OVRPlugin.Step.Render).
                ToOVRPose().orientation;
        Quaternion VRrotation = new Quaternion(quatf_orientation.x, quatf_orientation.y,
                                                quatf_orientation.z, quatf_orientation.w);
        Quaternion R2 = new Quaternion();
        XRDeviceManager.get_device(XRNode.Head).TryGetFeatureValue(CommonUsages.deviceRotation, out R2);
        TM.text = VRrotation.ToString("F2") + "\t|" + R2.ToString("F2");
    }
}
