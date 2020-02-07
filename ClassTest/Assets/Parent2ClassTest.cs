using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    protected virtual void Start()
    {
        test_action += testaction_func1;
        Debug.Log("Parent2ClassTest start");
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        //test_action();
        //Debug.Log("Parent2ClassTest update");
    }

    virtual public void testaction_func1()
    {
        Debug.Log("testaction_func1");
    }

    public void test_func2()
    {
        test_func22();
    }

    protected virtual void test_func22()
    {
        Debug.Log("Parent !!! test_func22");
    }

    protected virtual void OnDestroy()
    {
        Debug.Log("Parent2ClassTest OnDestroy");
    }

    protected virtual void OnApplicationQuit()
    {
        Debug.Log("Parent2ClassTest OnApplicationQuit");
    }

    protected virtual int exception_test()
    {
        //throw new NotImplementedException();  //not good;
        return -1;
    }
}
