using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathTest {

    public static void tanTest()
    {
        Debug.Log("Mathf.Tan(0)" + Mathf.Tan(0));
        Debug.Log("Mathf.Tan(45) "+Mathf.Tan(45));
        Debug.Log("Mathf.Tan((45.0f*Mathf.PI/180.0f)) " + Mathf.Tan((45.0f*Mathf.PI/180.0f)));
        Debug.Log("Mathf.Atan(1) " + Mathf.Atan(1));
        Debug.Log("Mathf.Atan(1)/Mathf.PI*180 " + Mathf.Atan(1)/Mathf.PI*180);
    }


}
