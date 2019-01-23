using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent2ClassTest : MonoBehaviour
{
    public System.Action test_action;

    public int a;

    virtual protected void Awake()
    {
        this.test_action = null;
        Debug.Log("Parent2ClassTest Awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        test_action += testaction_func1;
        Debug.Log("Parent2ClassTest start");
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        test_action();
        Debug.Log("Parent2ClassTest update");
    }

    virtual public void testaction_func1()
    {
        Debug.Log("testaction_func1");
    }
}
