using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceParent : MonoBehaviour, InterfaceTestIF
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void printa()
    {
        Debug.Log("a");
    }

    public virtual void printb()
    {
        Debug.Log("b");
    }
}
