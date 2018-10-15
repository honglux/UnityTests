using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int out1;
        string out2;
        List<int> out3;
        outtest(out out1, out out2, out out3);

        Debug.Log("int " + out1);
        Debug.Log("string " + out2);
        Debug.Log("list " + out3.Count);
        Debug.Log("list " + out3[0]);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void outtest(out int out1,out string out2,out List<int> out3)
    {
        out1 = 1;
        out2 = "abc";
        out2 = "def";
        out3 = new List<int>();
        out3.Add(10);
    }
}
