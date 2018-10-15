using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefTest : MonoBehaviour {

    private int ref_test1;

	// Use this for initialization
	void Start () {
        this.ref_test1 = 1;

    }
	
	// Update is called once per frame
	void Update () {

        ppref_test1(ref ref_test1);
        Debug.Log("ref_test1" + ref_test1);

	}

    private void ppref_test1(ref int t1)
    {
        t1++;
    }
}
