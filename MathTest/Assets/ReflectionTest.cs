using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectionTest : MonoBehaviour
{
    [SerializeField] private Transform o_TRANS;
    [SerializeField] private Transform d_TRANS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        d_TRANS.position = Vector3.Reflect(-(o_TRANS.position), new Vector3(1.0f, 0.0f, 0.0f));
    }
}
