using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariable
{

    private int a = 0;
    public static int ref_counter = 0;

    public StaticVariable()
    {
        ref_counter++;
    }

}
