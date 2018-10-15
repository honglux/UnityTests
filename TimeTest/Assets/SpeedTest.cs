using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class SpeedTest : MonoBehaviour {

    public TargetObj targetObj;


    private int startcounter;

    private int temp;
    private int target_counter;

    private int state;

    private Thread thread1;
    private Thread thread2;
    private Thread thread3;

    // Use this for initialization
    void Start () {
        this.startcounter = 0;
        this.temp = 0;
        this.target_counter = targetObj.counter;
        this.state = 0;
        this.thread1 = new Thread(timecalculate);
        thread1.Start();
    }
	
	// Update is called once per frame
	void Update () {
        startcounter++;
        if(startcounter == 1000)
        {
            testspeed1();
        }
        if (startcounter == 1200)
        {
            testspeed1();
        }
        if (startcounter == 1400)
        {
            testspeed1();
        }
    }

    private void testspeed1()
    {
        Debug.Log("testspeed1()");
        state = 1;
        for (int i = 0; i < 1000000000; i++)
        {
            temp += target_counter;
        }
        state = 2;
    }

    private void testspeed2()
    {
        Debug.Log("testspeed2()");
        state = 1;
        for (int i = 0; i < 1000000000; i++)
        {
            temp += targetObj.counter;
        }
        state = 2;
    }

    private void testspeed3()
    {
        Debug.Log("testspeed3()");
        state = 1;
        for (int i = 0; i < 1000000000; i++)
        {
            temp += targetObj.counter2;
        }
        state = 2;
    }

    private void timecalculate()
    {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

        while(state>=0)
        {
            if(state == 1)
            {
                stopwatch.Start();
                state = 0;
            }
            else if(state == 2)
            {
                stopwatch.Stop();
                Debug.Log("stopwatch " + stopwatch.ElapsedMilliseconds);
                stopwatch.Reset();
                state = 0;
            }
        }
    }

    private void OnApplicationQuit()
    {
        state = -1;
        try
        {
            thread1.Abort();
        }
        catch { }
    }
}
