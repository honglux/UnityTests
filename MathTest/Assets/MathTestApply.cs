using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTestApply : MonoBehaviour
{
    [SerializeField] private Transform tar1;
    [SerializeField] private Transform tar2;
    [SerializeField] private Transform tar3;

    [SerializeField] private float angle;

    // Start is called before the first frame update
    void Start()
    {
        //MathTest.natural_log();
        //MathTest.int_division();
        //test1();
        test2();
    }

    // Update is called once per frame
    void Update()
    {
        test3();
    }

    private void test1()
    {
        float a = 0.125f + (0.75f / (1.0f + Mathf.Pow((float)0 / (float)0, 2)));
        Debug.Log(a.ToString());
    }
    
    private void test2()
    {
        Debug.Log(Mathf.Rad2Deg * Mathf.Atan2(0.0f, 1.0f));
        Debug.Log(Mathf.Rad2Deg * Mathf.Atan2(1.0f, 0.0f));
        Debug.Log(Mathf.Rad2Deg * Mathf.Atan2(0.0f, -1.0f));
        Debug.Log(Mathf.Rad2Deg * Mathf.Atan2(-1.0f, 0.0f));
    }

    private void test3()
    {
        float r = Vector3.Magnitude(tar1.position);
        float tar1_ang = Mathf.Rad2Deg * Mathf.Atan2(tar1.position.y, tar1.position.x);
        float ang = tar1_ang + angle;
        float x = Mathf.Cos((ang) * Mathf.Deg2Rad) * r;
        float y = Mathf.Sin((ang) * Mathf.Deg2Rad) * r;
        tar2.position = new Vector3(x, y, 0.0f);
        ang = tar1_ang - angle;
        x = Mathf.Cos((ang) * Mathf.Deg2Rad) * r;
        y = Mathf.Sin((ang) * Mathf.Deg2Rad) * r;
        tar3.position = new Vector3(x, y, 0.0f);
    }
}
