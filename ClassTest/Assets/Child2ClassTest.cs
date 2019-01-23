using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child2ClassTest : Parent2ClassTest
{
    [SerializeField] private int b;

    override protected void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
    }

    override public void testaction_func1()
    {
        Debug.Log("child testaction_func1");
    }
}
