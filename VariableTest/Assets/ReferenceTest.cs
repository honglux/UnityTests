using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceTest : MonoBehaviour {

    private Color color;

	// Use this for initialization
	void Start () {
        color = GetComponent<MeshRenderer>().material.color;

        color = Color.red;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
