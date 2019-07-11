using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public static class MathTest {

    static MathTest()
    {
    }

    public static void tanTest()
    {
        Debug.Log("Mathf.Tan(0)" + Mathf.Tan(0));
        Debug.Log("Mathf.Tan(45) "+Mathf.Tan(45));
        Debug.Log("Mathf.Tan((45.0f*Mathf.PI/180.0f)) " + Mathf.Tan((45.0f*Mathf.PI/180.0f)));
        Debug.Log("Mathf.Atan(1) " + Mathf.Atan(1));
        Debug.Log("Mathf.Atan(1)/Mathf.PI*180 " + Mathf.Atan(1)/Mathf.PI*180);
    }

    public static void list_vector_test()
    {
        List<Vector2> lv2 = new List<Vector2>();
        for(int i = 0;i<10;i++)
        {
            lv2.Add(new Vector2(i, i + 5));
        }
        //Debug.Log("list_vector_test "+lv2.Average())  //failed;
    }

    public static void math_test()
    {
        Debug.Log("Mathf.Pow(3, 4)" + Mathf.Pow(3, 4));
    }

    public static void natural_log()
    {
        Debug.Log("natural_log " + Math.Log(Math.E));
    }

}
