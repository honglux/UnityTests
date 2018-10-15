using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniTest : MonoBehaviour {

    private int counter = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (counter <= 3)
        {
            transform.position = new Vector3(10.0f, 10.0f, 10.0f);
        }

        counter++;
	}

    public void changepos()
    {
        transform.position = new Vector3(10.0f, 10.0f, 10.0f);
    }
}
