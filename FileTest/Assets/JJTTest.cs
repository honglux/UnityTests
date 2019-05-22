using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class JJTTest
{
    public string Test1 = "aaa";

    //Can not be property!!!
    public string Test2 { get; set; }
    
    public JJTTest()
    {
        Test1 = "aaa";
        Test2 = "bbb";
    }
}
