using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereLR : MonoBehaviour
{
    [SerializeField] private Vector3 Force;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("spherel"))
    //    {
    //        Debug.Log("Detected 1!!!");
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("spherel"))
        {
            Debug.Log("Detected 1!!!");
        }
    }
}
