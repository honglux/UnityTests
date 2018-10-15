using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CParent: MonoBehaviour {

    public GameObject main_camera;
    public float scale;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(-1 * (main_camera.transform.position.x),
                    -1 * (main_camera.transform.position.y),
                    -1 * (main_camera.transform.position.z));

        transform.rotation = new Quaternion(-scale * main_camera.transform.rotation.x,
                                            -scale * main_camera.transform.rotation.y,
                                            -scale * main_camera.transform.rotation.z,
                                            main_camera.transform.rotation.w);


        //Vector3 a = new Vector3(-1 * (main_camera.transform.position.x),
        //                    -1 * (main_camera.transform.position.y),
        //                    -1 * (main_camera.transform.position.z));
        //transform.Translate(a, Space.World);

    }
}
