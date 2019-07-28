using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class ListTestClass
{

    public int test1;

    public ListTestClass()
    {
        this.test1 = 0;
    }

    public ListTestClass(ListTestClass LTC)
    {
        test1 = LTC.test1;
    }

    public ListTestClass clone()
    {
        return new ListTestClass(this);
    }


}
