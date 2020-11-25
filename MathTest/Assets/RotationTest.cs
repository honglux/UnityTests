using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private Transform indicator;
    [SerializeField] private Vector3 input;
    
    // Start is called before the first frame update
    void Start()
    {
        //test1();
        //test2();
    }

    // Update is called once per frame
    void Update()
    {
        test3();
    }

    private void test1()
    {
        Debug.Log(Quaternion.LookRotation(new Vector3(2.0f,2.0f,0.0f), Vector3.up).eulerAngles.ToString());
    }

    private void test2()
    {
        Quaternion rotate1 = Quaternion.Euler(90.0f, 90.0f, 0.0f);
        Vector3 a = rotate1 * Vector3.forward;
        Debug.Log(a);
    }

    private void test3()
    {
        Vector3 dir = Quaternion.Euler(input) * parent.forward;
        indicator.position = dir;
    }
}
