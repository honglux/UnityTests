using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryTest : MonoBehaviour {

    Dictionary<string, string> dtest1 = new Dictionary<string, string>();
    Dictionary<float, int> dtest2 = new Dictionary<float, int>();

    // Use this for initialization
    void Start () {
        //dtest1.Add("123", "456");

        //Debug.Log("dtest1['123']" + dtest1["123"]);

        //try
        //{
        //    string test1 = dtest1["234"];
        //    Debug.Log("test1" + test1);
        //}
        //catch
        //{
        //    Debug.Log("catched");
        //}
        Debug.Log("dtest2 " + dtest2.ContainsKey(0.3f));
        dtest2.Add(0.3f, 3);
        Debug.Log("dtest2 " + dtest2.ContainsKey(0.3f));

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
