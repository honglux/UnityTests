using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructorTest : MonoBehaviour
{
    private int a = 0;

    /// <summary>
    /// This will be called multiple times, not a good method;
    /// </summary>
    public ConstructorTest()
    {
        Debug.Log("ContstructorTest constructor");
        a = 100;
        Debug.Log("ContstructorTest a"+a);
    }

    private void Awake()
    {
        Debug.Log("ContstructorTest awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ContstructorTest start");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
