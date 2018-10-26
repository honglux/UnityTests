using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAni : MonoBehaviour {

    static int Print1Hash = Animator.StringToHash("Test");
    static int FullPrint1Hash = Animator.StringToHash("Base Layer.Test");

    private Animator cube_ani;

    float timer;

    float last_time;
    float current_time;

    System.Diagnostics.Stopwatch stopwatch;
    private long last_millsecond;

	// Use this for initialization
	void Start () {
        cube_ani = GetComponent<Animator>();
        timer = 3.0f;
        last_time = 0.0f;

        this.stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        this.last_millsecond = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("update time " + Time.deltaTime.ToString("F3"));

        timer -= Time.deltaTime;
        Debug.Log("cube_ani.GetCurrentAnimatorStateInfo(0) " + cube_ani.GetCurrentAnimatorStateInfo(0).nameHash);
        Debug.Log("Print1Hash " + Print1Hash);
        Debug.Log("cube_ani.GetCurrentAnimatorStateInfo(0) fullPathHash " + cube_ani.GetCurrentAnimatorStateInfo(0).fullPathHash);
        Debug.Log("FullPrint1Hash " + FullPrint1Hash);
        //switch(cube_ani.GetCurrentAnimatorStateInfo(0).fullPathHash)
        //{
        //    case FullPrint1Hash:
        //        {
        //            Debug.Log("state catched");
        //            break;
        //        }
        //}

        //if (cube_ani.GetCurrentAnimatorStateInfo(0).nameHash == Print1Hash)
        //{
        //    Debug.Log("State Print1");
        //}

        //if(cube_ani.GetCurrentAnimatorStateInfo(0).IsName("UpdateTest1"))
        //{
        //    Debug.Log("UpdateTest1");
        //    timer -= Time.deltaTime;
        //    if(timer < 0.0f)
        //    {
        //        timer = 3.0f;
        //        cube_ani.SetTrigger("Next");
        //    }
        //}
        //if(cube_ani.GetCurrentAnimatorStateInfo(0).IsName("UpdateTest2"))
        //{
        //    Debug.Log("UpdateTest2");
        //}

    }

    public void print1ani()
    {
        //if(timer < 0.0f)
        //{
        //    Debug.Log("print1ani");
        //    Debug.Log("timer"+ timer);
        //    cube_ani.SetTrigger("Next");
        //    timer = 3.0f;
        //}

        //cube_ani.SetTrigger("Next");
        //while(true)
        //{

        //}

    }

    public void print2ani()
    {
        if (timer < 0.0f)
        {
            Debug.Log("print2ani");
            Debug.Log("timer"+ timer);
            cube_ani.SetTrigger("Next");
            timer = 3.0f;
        }
    }

    public void printtimer()
    {
        current_time = Time.time;
        float time_diff = current_time - last_time;
        Debug.Log("time_diff" + time_diff);
        last_time = Time.time;
    }

    public void print_timer2()
    {
        long current = stopwatch.ElapsedMilliseconds;
        Debug.Log("print_timer2 "+ (current-last_millsecond));
        last_millsecond = current;
    }
}
