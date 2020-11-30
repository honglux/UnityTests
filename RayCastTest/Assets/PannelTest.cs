using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelTest : MonoBehaviour
{
    [SerializeField] private Transform target_TRANS;

    private RaycastHit hits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        test1();
    }

    private void test1()
    {
        bool hitted = Physics.Raycast(new Ray(transform.position, transform.forward), out hits, 100.0f);
        if(hitted && GameObject.ReferenceEquals(hits.transform.gameObject,target_TRANS.gameObject))
        {
            Debug.Log("Hitted");
        }
    }
}
