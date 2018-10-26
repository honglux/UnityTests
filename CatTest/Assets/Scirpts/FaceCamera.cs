using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour {

    public Transform TargetTrans;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(TargetTrans);

        gameObject.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));

    }
}
