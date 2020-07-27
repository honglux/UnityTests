using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCT2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshCollider mc = gameObject.AddComponent<MeshCollider>();
        mc.convex = true;
        gameObject.AddComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
