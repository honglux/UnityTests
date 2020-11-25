using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTestApply : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //MathTest.natural_log();
        //MathTest.int_division();
        test1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void test1()
    {
        float a = 0.125f + (0.75f / (1.0f + Mathf.Pow((float)0 / (float)0, 2)));
        Debug.Log(a.ToString());
    }
}
