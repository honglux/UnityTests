using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentTest2 : MonoBehaviour
{
    private float timer = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ComponentTest2 started");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = float.MaxValue;
            Debug.Log("timer < 0");
        }
    }
}
