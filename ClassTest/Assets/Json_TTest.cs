using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum enum_test { a,b,c};

[Serializable]
public class Json_TTest
{
    //Has to be public;
    public string test1;
    public float test2;
    public enum_test test3;

    public Json_TTest()
    {
        test1 = "ccc";
        test2 = float.MaxValue;
        test3 = enum_test.b;
    }

}
