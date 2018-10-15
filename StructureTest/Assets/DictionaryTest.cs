using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryTest : MonoBehaviour {

    Dictionary<string, string> dtest1 = new Dictionary<string, string>();

	// Use this for initialization
	void Start () {
        dtest1.Add("123", "456");

        Debug.Log("dtest1['123']" + dtest1["123"]);
        
        try
        {
            string test1 = dtest1["234"];
            Debug.Log("test1" + test1);
        }
        catch
        {
            Debug.Log("catched");
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
