﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCall : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("static a " + StaticClassTest.a);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
