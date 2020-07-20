using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class JJTTest
{
    public string Test1 = "aaa";
    public List<List<int>> Test3;   //Not supported!!!
    public JsonSelfClassTest JSC;

    //Can not be property!!!
    public string Test2 { get; set; }
    
    public JJTTest()
    {
        Test1 = "ccc";
        Test2 = "bbb";
        this.Test3 = new List<List<int>>();
        Test3.Add(new List<int>() { 1, 2, 3 });
        Test3.Add(new List<int>() { 4, 5, 6 });
        this.JSC = new JsonSelfClassTest();
    }
}
