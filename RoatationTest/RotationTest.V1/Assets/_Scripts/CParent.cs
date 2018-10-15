using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CParent: MonoBehaviour {

    //public GameObject main_camera;
    public float scale;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        transform.rotation = new Quaternion(-scale * InputTracking.GetLocalRotation(XRNode.Head).x,
                                            -scale * InputTracking.GetLocalRotation(XRNode.Head).y,
                                            -scale * InputTracking.GetLocalRotation(XRNode.Head).z,
                                            InputTracking.GetLocalRotation(XRNode.Head).w);

        //transform.position = new Vector3(-1 * (InputTracking.GetLocalPosition(XRNode.Head).x),
        //                    -1 * (InputTracking.GetLocalPosition(XRNode.Head).y),
        //                    -1 * (InputTracking.GetLocalPosition(XRNode.Head).z));       

    }
}
