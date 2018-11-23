using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionQueue : MonoBehaviour {

    public Queue<Transform> PosQueue;

	// Use this for initialization
	void Start () {
        this.PosQueue = new Queue<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
