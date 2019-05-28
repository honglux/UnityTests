using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("x " + Input.GetAxis("Horizontal"));
        Debug.Log("y " + Input.GetAxis("Vertical"));
        Debug.Log("5 " + Input.GetKey(KeyCode.JoystickButton5));
    }
}
