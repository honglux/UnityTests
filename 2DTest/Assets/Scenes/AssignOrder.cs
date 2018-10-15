using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignOrder : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //GetComponent<SpriteRenderer>().sortingOrder = 1;
        GetComponent<SpriteRenderer>().sortingOrder = -1 * (int)(transform.position.y * 100);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
