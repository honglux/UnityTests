using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticClassTest
{

    public static int a;

    static StaticClassTest()
    {
        a = 10;
    }

    public static IEnumerator IEstatic_test(int input)
    {
        while(true)
        {
            Debug.Log("IEstatic_test " + input);
            yield return new WaitForSeconds(1.0f);
        }
    }

}
