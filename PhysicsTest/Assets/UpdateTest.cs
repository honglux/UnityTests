using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(wait_for_fix());
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    private IEnumerator wait_for_fix()
    {
        while(true)
        {
            Debug.Log("Update before");
            yield return new WaitForFixedUpdate();
            Debug.Log("Update after");
        }
    }
}
