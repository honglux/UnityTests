using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child2ClassTest : Parent2ClassTest
{
    [SerializeField] private int b;

    private int count = 1;

    //override protected void Awake()
    //{
    //    base.Awake();
    //}

    protected override void Start()
    {
        Debug.Log("exception_test() res " + exception_test());
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();

        count++;
        if(count>300)
        {
            //Destroy(gameObject);
        }
    }

    override public void testaction_func1()
    {
        Debug.Log("child testaction_func1");
    }

    protected override int exception_test()
    {
        Debug.Log("exception_test1");
        base.exception_test();
        Debug.Log("exception_test2");
        return -2;
    }

    protected override void test_func22()
    {
        Debug.Log("Child @@@ test_func22");
    }
}
