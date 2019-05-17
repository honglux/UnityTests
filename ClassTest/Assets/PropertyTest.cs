using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class PropertyTest : MonoBehaviour
{

    [SerializeField] private PT_target ptt;

    // Start is called before the first frame update
    void Start()
    {
        System.Reflection.PropertyInfo[] p = ptt.GetType().GetProperties();
        Debug.Log("number " + p.Length);
        foreach(System.Reflection.PropertyInfo _p in p)
        {
            try
            {
                Debug.Log("---------");
                Debug.Log("name " + _p.Name);
                Debug.Log("value " + _p.GetValue(ptt).ToString());
            }
            catch { }
            
        }

        //TypeAttributes TA =  ptt.GetType().Attributes;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
