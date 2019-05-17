using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cannot be Monobehavior!!!!
[System.Serializable]
public class TestData
{
    public int test1;
    public int test2;

    public TestData()
    {
        this.test1 = 10;
        this.test2 = 100;
    }

    public void set_data(int test1)
    {
        this.test1 = test1;
    }
}
