using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StopWatchTest : MonoBehaviour
{
    [SerializeField] private TextMesh TM1;
    [SerializeField] private TextMesh TM2;
    [SerializeField] private TextMesh TM3;

    private System.Diagnostics.Stopwatch SP;

    // Start is called before the first frame update
    void Start()
    {
        this.SP = new System.Diagnostics.Stopwatch();
        SP.Start();
    }

    // Update is called once per frame
    void Update()
    {

        TM1.text = SP.ElapsedMilliseconds.ToString("F3");
        TM2.text = SP.Elapsed.Milliseconds.ToString("F3");

    }
}
