using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParentClassTest : MonoBehaviour {

    public int vartest1 = 0;


    virtual public void testfunction1()
    {
        vartest1 = 1;
    }

    virtual public void update_test1()
    {
        Debug.Log("parent update_test1");
    }

}
