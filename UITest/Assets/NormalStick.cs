using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStick : MonoBehaviour
{
    [SerializeField] private UIPanel UIP_script;

    public Collider last_collider { get; set; }

    private void Start()
    {
        last_collider = null;
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
            if(last_collider != null)
            {
                Color gray = Color.gray;
                gray.a = 0.5f;
                last_collider.GetComponent<MeshRenderer>().material.color = gray;
            }
            Color white = Color.white;
            white.a = 0.5f;
            other.GetComponent<MeshRenderer>().material.color = white;
            last_collider = other;
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
