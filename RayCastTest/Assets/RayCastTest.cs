using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTest : MonoBehaviour {

    //private RaycastHit hit;
    private Transform objectHit;
    private bool hit_flag;
    private bool hit_center_flag;
    private bool hit_centest_flag;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        ////Ray cast one;
        //Ray ray = new Ray(transform.position, transform.forward);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit))
        //{
        //    objectHit = hit.transform;
        //}
        //else
        //{
        //    objectHit = null;
        //}

        ////Debug.Log(objectHit);

        //hit_flag = false;
        //hit_center_flag = false;
        //hit_centest_flag = false;

        //if (objectHit != null)
        //{
        //    if (objectHit.tag == "TargetOne")
        //    {
        //        Debug.Log("TargetOne");
        //        hit_flag = true;
        //        return;
        //    }

        //}

        //Ray cast two;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray,100.0f);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            objectHit = hit.transform;

            if (objectHit != null)
            {
                Debug.Log("objectHit "+objectHit.tag);
            }
        }

    }

    public bool get_hit_flag()
    {
        return hit_flag;
    }

    public bool get_hit_center_flag()
    {
        return hit_center_flag;
    }
    public bool get_hit_centest_flag()
    {
        return hit_centest_flag;
    }
}
