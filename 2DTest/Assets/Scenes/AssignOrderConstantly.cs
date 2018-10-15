using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignOrderConstantly : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().sortingOrder = -1 * (int)(transform.position.y * 100);
	}
}
