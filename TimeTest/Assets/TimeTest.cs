using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeTest : MonoBehaviour {

    [SerializeField] private float IntervalTime;
    [SerializeField] public float TestTime;
    [SerializeField] private TextMesh Text1;
    [SerializeField] private TextMesh Text2;
    [SerializeField] private TextMesh Text3;

    private float self_timer;
    public bool Timer_flag { private set; get; }
    private Animator animator;
    public float ani_timer { get; set; }
    private float inter_timer;

	// Use this for initialization
	void Start () {
        this.self_timer = 0.0f;
        this.Timer_flag = false;
        this.ani_timer = 0.0f;
        this.inter_timer = 0.0f;
        this.animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Text1.text = self_timer.ToString("F2");
        Text2.text = ani_timer.ToString("F2");
        Text3.text = (1 / Time.deltaTime).ToString("F2");

        if (Timer_flag)
        {
            self_timer -= Time.deltaTime;
            if(self_timer < 0.0f)
            {
                Timer_flag = false;
            }
        }

        inter_timer -= Time.deltaTime;
        if(inter_timer < 0.0f)
        {
            reset_timer();
            start_timer();
            inter_timer = IntervalTime;
        }



    }

    private void start_timer()
    {
        Timer_flag = true;
        animator.GetBehaviour<Timer>().start_timer();
    }

    private void reset_timer()
    {
        self_timer = TestTime;
        Timer_flag = true;
        animator.GetBehaviour<Timer>().reset_timer();
    }


}
