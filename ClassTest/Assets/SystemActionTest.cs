using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemActionTest : MonoBehaviour
{
    System.Action<int> action_test1;

    // Start is called before the first frame update
    void Start()
    {
        action_test1 += test1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void test1(int i)
    {
        Debug.Log("test1 " + i);
    }
}
