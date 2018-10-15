using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutUpdateTest : MonoBehaviour {

    private ParentClassTest parentClassTest;

    // Use this for initialization
    void Start () {
        parentClassTest = GetComponent<ParentClassTest>();
	}
	
	// Update is called once per frame
	void Update () {
        parentClassTest.update_test1();
	}
}
