using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform HeadTrans;
    public InputController IPC_script;

    public float MouseSensitivity = 1.0f;
    public float MoveSpeed = 1.0f;

    private Rigidbody RB;

	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void FixedUpdate()
    {
        //Mouse Horizontal rotate;
        RB.MoveRotation(RB.rotation * 
            Quaternion.Euler(new Vector3(0, IPC_script.Mouse_X * MouseSensitivity, 0)));

        //Keyboard mvoe;
        float y_vel = RB.velocity.y;
        RB.velocity = ((IPC_script.Keyboard_vertical*transform.forward + 
                        IPC_script.Keyboard_horizontal*transform.right).normalized)*MoveSpeed
                            + new Vector3(0.0f,y_vel,0.0f);

        //Mouse vertical rotate;
        HeadTrans.Rotate(-IPC_script.Mouse_Y * MouseSensitivity, 0.0f, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPCTrigger")
        {
            other.GetComponentInParent<NPC>().ableto_talk();
        }
        else if(other.tag == "CatTrigger")
        {
            other.GetComponentInParent<Cat>().try_picking_up();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPCTrigger")
        {
            other.GetComponentInParent<NPC>().unableto_talk();
        }
    }
}
