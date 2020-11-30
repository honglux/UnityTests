using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceTest : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private Transform child;

    // Start is called before the first frame update
    void Start()
    {
        parent.GetComponent<InterfaceTestIF>().printa();
        child.GetComponent<InterfaceTestIF>().printb();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
