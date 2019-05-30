using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Transform camera_TRANS;
    [SerializeField] private float Speed = 1.0f;
    [SerializeField] private Transform camera2_TRNAS;
    [SerializeField] private Transform portal_TRANS;

    private Vector3 pos_diff;

    void Start()
    {
        pos_diff = camera2_TRNAS.position - camera_TRANS.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            camera_TRANS.position = new Vector3(camera_TRANS.position.x - Time.deltaTime * Speed,
                                                camera_TRANS.position.y, 
                                                camera_TRANS.position.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            camera_TRANS.position = new Vector3(camera_TRANS.position.x,
                                                camera_TRANS.position.y - Time.deltaTime * Speed, 
                                                camera_TRANS.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            camera_TRANS.position = new Vector3(camera_TRANS.position.x + Time.deltaTime * Speed,
                                                camera_TRANS.position.y, 
                                                camera_TRANS.position.z);
        }
        if (Input.GetKey(KeyCode.W))
        {
            camera_TRANS.position = new Vector3(camera_TRANS.position.x,
                                                camera_TRANS.position.y + Time.deltaTime * Speed,
                                                camera_TRANS.position.z);
        }

        //Vector3 dir = (portal_TRANS.position - camera_TRANS.position).normalized;
        //Quaternion rotation = Quaternion.LookRotation(dir);
        //camera2_TRNAS.rotation = rotation;

        camera2_TRNAS.position = -camera_TRANS.position + pos_diff;
    }
}
