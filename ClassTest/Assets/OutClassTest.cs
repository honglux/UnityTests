using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutClassTest : MonoBehaviour {

    public GameObject testGO1;
    public GameObject testGO2;

	// Use this for initialization
	void Start () {

        testGO1.GetComponent<ParentClassTest>().testfunction1();

        Debug.Log("testGO2.GetComponent<ParentClassTest>().vartest1 "
                    + testGO2.GetComponent<ParentClassTest>().vartest1); 

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
