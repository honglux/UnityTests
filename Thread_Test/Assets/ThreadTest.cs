using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ThreadTest : MonoBehaviour {

    private bool stop_flag;
    private Thread thread;
    public GameObject cube;
    public float x = 0.0f;
    public float timer = 10.0f;

    // Use this for initialization
    void Start () {
        this.stop_flag = false;
        this.cube = GameObject.Find("Cube");
        //Debug.Log("cube ", cube);
        this.thread = new Thread(thread1_test);
        thread.Start();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f));
        x = transform.rotation.x;
        timer -= Time.deltaTime;
        if(timer < 0.0f)
        {
            stop_flag = true;
        }
	}

    void thread1_test()
    {
        
        while(!stop_flag)
        {
            //Debug.Log("x "+x);
            //Debug.Log("timer " + timer);
        }
    }
}
