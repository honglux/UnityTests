using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class ControllerController : MonoBehaviour {
    private bool act_flag;
    private float leftm;
    private float rightm;
    private const float increase = 0.5f;
	// Use this for initialization
	void Start () {
        act_flag = false;
        leftm = 0.0f;
        rightm = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("z"+rightm+leftm);
            //if (!act_flag)
            //{
            //    GamePad.SetVibration(0, 0.5f, 0.5f);
            //}
            if(leftm <= 2.0f)
            {
                leftm += increase;
            }
            else
            {
                rightm += increase;
            }
            if (rightm > 2.0f)
            {
                leftm = 0.0f;
                rightm = 0.0f;
            }
            GamePad.SetVibration(0, leftm, rightm);
        }
        GamePad.GetState(0);
        Debug.Log("z" + rightm + leftm);
    }
}
