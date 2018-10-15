using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObj : MonoBehaviour {

    public int counter;
    public int counter2 { get; set; }

	// Use this for initialization
	void Start () {
        counter = 0;
        counter2 = 0;
    }
	
	// Update is called once per frame
	void Update () {
        counter++;
        counter2++;
	}
}
