using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariableCall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StaticVariable a = new StaticVariable();
        StaticVariable b = new StaticVariable();
        StaticVariable c = new StaticVariable();
        StaticVariable d = new StaticVariable();

        Debug.Log("StaticVariable " + StaticVariable.ref_counter);
        //Debug.Log("d " + d.ref_counter);  //Wrong;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
