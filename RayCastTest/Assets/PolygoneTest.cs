using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygoneTest : MonoBehaviour
{
    private RaycastHit hits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        test1();
    }

    private void test1()
    {
        bool hitted = Physics.Raycast(new Ray(transform.position, transform.forward), out hits, 100.0f);
        Debug.Log(hitted);
        Debug.Log(hits.transform.name);
    }
}
