using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstacneTestGo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParentInstanceTest.IS.test1();
        //InstanceTest.IS.test2();  //Failed;
        InstanceTest.Instance.test2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
