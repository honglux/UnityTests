using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public float Mouse_X { get; set; }
    public float Mouse_Y { get; set; }
    public float Keyboard_horizontal { get; set; }
    public float Keyboard_vertical { get; set; }
    public bool Action_key_pressed { get; set; }


	// Use this for initialization
	void Start () {
        this.Mouse_X = 0.0f;
        this.Mouse_Y = 0.0f;
        this.Keyboard_horizontal = 0.0f;
        this.Keyboard_vertical = 0.0f;
        this.Action_key_pressed = false;
    }
	
	// Update is called once per frame
	void Update () {
        Mouse_X = Input.GetAxis("Mouse X");
        Mouse_Y = Input.GetAxis("Mouse Y");
        Keyboard_horizontal = Input.GetAxisRaw("Horizontal");
        Keyboard_vertical = Input.GetAxisRaw("Vertical");

        Action_key_pressed = false;
        if(Input.GetKeyDown(KeyCode.E))
        {
            Action_key_pressed = true;
        }
    }
}
