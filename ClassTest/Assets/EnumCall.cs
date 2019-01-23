using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumCall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("EnumTest1 a " + EnumTest1.a);
        Debug.Log("EnumTest2 a " + EnumClassTest.EnumTest2.a);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
