using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
    [SerializeField] private int NUM;

    private List<int> mem_consumer;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<NUM;i++)
        {
            mem_consumer.Add(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
