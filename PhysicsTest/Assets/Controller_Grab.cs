using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Grab : MonoBehaviour {

    [SerializeField] GrabTrigger GT_script;
    [SerializeField] Controller_Input CI_script;
    //[SerializeField] Transform FixJoint;
    [SerializeField] private Transform Controller_TRANS;

    [SerializeField] private int speed_cal_limit = 10;

    private bool empty_grabed;
    private bool grab_triggered;
    private Transform last_other;
    private Queue<Vector3> speed_queue;
    private Vector3 last_contro_pos;
    private Vector3 ave_speed;

    // Use this for initialization
    void Start () {
        this.empty_grabed = false;
        this.grab_triggered = false;
        this.speed_queue = new Queue<Vector3>();
        this.last_contro_pos = new Vector3();
        this.ave_speed = new Vector3();
    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log("contr vel " + OVRInput.GetLocalControllerVelocity(CI_script.Controller_type));
        //Debug.Log("ave_speed " + ave_speed);

        //if(Input.GetAxis("Oculus_CrossPlatform_SecondaryHandTrigger") > 0.5f)
        //      {
        //          grab_button_down = true;
        //      }
        //      else
        //      {
        //          grab_button_down = false;
        //          empty_grabed = false;
        //          release();
        //      }

        if (CI_script.Grab_falg && GT_script.other_TRANS == null)
        {
            empty_grabed = true;
        }
        else if(CI_script.Grab_falg && !empty_grabed && !grab_triggered)
        {
            grab_triggered = true;
            grab();
        }
        else if(!CI_script.Grab_falg)
        {
            empty_grabed = false;
            release();
        }

        if(GT_script.other_TRANS != null)
        {
            last_other = GT_script.other_TRANS;
        }


    }

    private void FixedUpdate()
    {
        speed_cal();
    }

    private void grab()
    {
        GetComponent<FixedJoint>().connectedBody =
                GT_script.other_TRANS.GetComponent<Rigidbody>();
        //Debug.Log("grab " + GT_script.other_TRANS.name);
        GT_script.disable_trigger();
    }

    private void release()
    {
        if(grab_triggered)
        {
            GetComponent<FixedJoint>().connectedBody = null;
            //last_other.GetComponent<Rigidbody>().velocity =
            //            transform.InverseTransformDirection(OVRInput.GetLocalControllerVelocity(CI_script.Controller_type));
            last_other.GetComponent<Rigidbody>().velocity = ave_speed;
            grab_triggered = false;
            GT_script.enable_trigger();
        }
    }
    
    private void speed_cal()
    {
        Vector3 current_speed = (Controller_TRANS.position - last_contro_pos) / Time.deltaTime;
        speed_queue.Enqueue(current_speed);
        last_contro_pos = Controller_TRANS.position;
        while (speed_queue.Count > speed_cal_limit)
        {
            speed_queue.Dequeue();
        }
        Vector3 sum_speed = Vector3.zero;
        foreach(Vector3 speed in speed_queue)
        {
            sum_speed += speed;
        }
        ave_speed = sum_speed / speed_queue.Count;
    }

}
