using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceChild : InterfaceParent
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void printa()
    {
        Debug.Log("aaa");
    }

    public override void printb()
    {
        Debug.Log("bbb");
    }
}
