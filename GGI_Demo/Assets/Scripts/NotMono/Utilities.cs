using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static void print_arr<T,U>(T arr, string str = "") where T : IEnumerable<U>
    {
        foreach(U elem in arr)
        {
            str += elem.ToString() + " | ";
        }
        Debug.Log(str);
    }

    public static void print_dict<T,U,V>(T dict, string str = "") where T:IDictionary<U,V>
    {
        foreach(KeyValuePair<U,V> k_v in dict)
        {
            str += k_v.Key + "_" + k_v.Value + "|";
        }
        Debug.Log(str);
    }
}
