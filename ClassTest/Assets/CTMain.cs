using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTMain : MonoBehaviour
{
    [SerializeField] private Transform CT_TRANS;
    [SerializeField] private ComponentTest CT_script;


    // Start is called before the first frame update
    void Start()
    {
        CT_TRANS.GetComponent<ComponentTest>().call_test();
        //CT_script.call_test();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
