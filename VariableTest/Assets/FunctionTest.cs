using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void test()
    {
        fun(0);
        fun(0, c: 0);
        fun(0, 0, c: 0);

        fun(0, 0);  //This is the one who cause problems;
        fun(0, 0, 0);
    }

    private void fun(int a, int c = 1)
    {
        Debug.Log("Fun1");
    }

    private void fun(int a, int b, int c = 1)
    {
        Debug.Log("Fun2");
    }
}
