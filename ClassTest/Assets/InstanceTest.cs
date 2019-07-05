using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceTest : MonoBehaviour
{
    public int a = 0;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        a++;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("InstanceTest " + a);
    }

    public static InstanceTest Instance { get; private set; }
}
