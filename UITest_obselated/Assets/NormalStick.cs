using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStick : MonoBehaviour
{
    [SerializeField] private UIPanel UIP_script;

    //private int button_index;
    private UIButtonColliderIndexes curr_UIButtonIndex;
    private UIButtonColliderIndexes last_UIButtonIndex;

    private void Start()
    {
        //this.button_index = 0;
        this.curr_UIButtonIndex = 0;
        this.last_UIButtonIndex = 0;
    }

    private void Update()
    {
        if(UIP_script.Controller_TRANS != null)
        {
            transform.position = UIP_script.Controller_TRANS.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "UIButton")
        {
            curr_UIButtonIndex = other.GetComponent<UIButtonCollider>().get_index();
            if(last_UIButtonIndex != curr_UIButtonIndex)
            {
                UIP_script.ButtonHoved(curr_UIButtonIndex);
                last_UIButtonIndex = curr_UIButtonIndex;
            }
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "UIButton")
    //    {
    //        Color gray = Color.gray;
    //        gray.a = 0.5f;
    //        other.GetComponent<MeshRenderer>().material.color = gray;
    //    }
    //}

}
