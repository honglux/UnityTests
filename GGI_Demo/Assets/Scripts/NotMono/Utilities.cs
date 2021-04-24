using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static void print_arr<T,U>(T arr) where T : IEnumerable<U>
    {
        string str = "";
        foreach(U elem in arr)
        {
            str += elem.ToString() + " | ";
        }
        Debug.Log(str);
    }
}
