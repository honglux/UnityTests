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

    public static void print_dict<T,U,V>(T dict) where T:IDictionary<U,V>
    {
        string str = "";
        foreach(KeyValuePair<U,V> k_v in dict)
        {
            str += k_v.Key + "_" + k_v.Value + "|";
        }
        Debug.Log(str);
    }
}
