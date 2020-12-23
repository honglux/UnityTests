using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCast : MonoBehaviour
{
    [SerializeField] private Transform indicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit_IF;
        if (Physics.SphereCast(transform.position, 3.0f, transform.forward, out hit_IF, 20.0f)) 
        {
            indicator.position = hit_IF.point;
        }
        Debug.Log(hit_IF.transform == null ? hit_IF.transform.ToString() : hit_IF.transform.name);
    }
}
