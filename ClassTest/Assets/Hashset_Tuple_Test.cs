using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Hashset_Tuple_Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //test1();
        test2();
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Tuple test;
    /// </summary>
    private void test1()
    {
        var a = (2, 1);
        Debug.Log(a.GetType());
    }

    /// <summary>
    /// Tuple with Hashset;
    /// </summary>
    private void test2()
    {
        HashSet<(int, int)> buf = new HashSet<(int, int)>();
        buf.Add((1, 2));
        Debug.Log(buf.Contains((1, 2)));
    }
}