using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Global : MonoBehaviour {

    public int glotesst1 { get; set; }

    private Thread testthread1;
    private int counter;
    private int update_counter;
    private bool stop_flag;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        this.glotesst1 = 200;
        this.counter = 0;
        this.update_counter = 0;
        this.stop_flag = false;

        this.testthread1 = new Thread(threadtest1);
        
    }

    private void Update()
    {
        if(update_counter == 60)
        {
            testthread1.Start();
        }
        update_counter++;
        if(update_counter % 10 == 0)
        {
            Debug.Log("counter " + counter);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Global OnDestroy Called");
        stop_flag = true;
    }

    private void threadtest1()
    {
        int inner_counter = 0;
        while(!stop_flag)
        {
            inner_counter++;
            if(inner_counter > 1000000)
            {
                Debug.Log("Reset");
                inner_counter = 0;
            }
            counter = inner_counter;
        }

        Debug.Log("innder_counter "+inner_counter);
    }


}
