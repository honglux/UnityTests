using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildClassTest : ParentClassTest
{

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    override public void testfunction1()
    {
        Debug.Log("ChildClassTest.testfunction1");
        vartest1 = 2;
        Debug.Log("vartest1 " + vartest1);
    }

    public override void update_test1()
    {
        Debug.Log("child update_test1");
    }
}
