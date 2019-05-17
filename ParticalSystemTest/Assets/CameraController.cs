using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float Speed = 1.0f;
    [SerializeField] float RotateSpeed = 1.0f;

    float yaw;
    float pitch;

    // Start is called before the first frame update
    void Start()
    {
        this.yaw = 0.0f;   
        this.pitch = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Speed * Time.deltaTime;
        }

        yaw += RotateSpeed * Input.GetAxis("Mouse X");
         pitch -= RotateSpeed * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
