using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    [SerializeField] private Transform MainBody;
    [SerializeField] private LayerMask TeleLayerMask;
    [SerializeField] private Controller_Input CI_script;

    public Vector3 hit_point { get; set; }

    private bool tele_flag;
    private bool tele_ready_flag;
    private float init_hight;
    private bool line_toggled;

	// Use this for initialization
	void Start () {
        this.hit_point = new Vector3();
        this.tele_flag = false;
        this.tele_ready_flag = false;
        this.init_hight = MainBody.position.y;
        this.line_toggled = false;
    }
	
	// Update is called once per frame
	void Update () {

        //if(Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") > 0.5f)
        //{
        //    tele_flag = true;
        //}
        //else
        //{
        //    tele_flag = false;
        //    teleport();
        //}
        //Debug.Log("Vertical " + Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical"));
        if(tele_ready_flag)
        {
            Vector3[] positions = { transform.position, hit_point };
            GetComponent<LineRenderer>().SetPositions(positions);
            GetComponent<LineRenderer>().enabled = true;
        }
        if(!CI_script.Forward_flag)
        {
            teleport();
        }

    }

    private void FixedUpdate()
    {
        if(CI_script.Forward_flag)
        {
            Ray ray = new Ray(transform.position, transform.forward);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, TeleLayerMask))
            {
                hit_point = hit.point;
                tele_ready_flag = true;
            }
            else
            {
                tele_ready_flag = false;
            }
            

        }


    }

    private void teleport()
    {
        if(tele_ready_flag)
        {
            MainBody.position = new Vector3(hit_point.x, init_hight, hit_point.z);
            GetComponent<LineRenderer>().enabled = false;
            tele_ready_flag = false;
        }
    }
}
