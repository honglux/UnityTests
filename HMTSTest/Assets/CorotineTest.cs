using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorotineTest : MonoBehaviour
{
    [SerializeField] private TextMesh tM1;
    [SerializeField] private TextMesh tM2;
    [SerializeField] private TextMesh tM3;
    [SerializeField] private TextMesh tM4;

    private System.Diagnostics.Stopwatch sW;
    private float timer1;
    private bool timer1_flag;
    private float timer2;
    private bool timer2_flag;
    private float timer3;
    private float pub_timer;
    private bool test_flag;
    private bool pub_flag;

    private void Awake()
    {
        this.sW = new System.Diagnostics.Stopwatch();
        this.timer1 = 0.0f;
        this.timer1_flag = false;
        this.timer2 = 0.0f;
        this.timer2_flag = false;
        this.timer3 = 0.0f;
        this.pub_timer = 0.0f;
        this.test_flag = false;
        this.pub_flag = false;
}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        test1();
        Process_RR();
    }

    private void test1()
    {
        Proc_pub_timer();
        Show_timer();
        Process_timer1();
    }

    private void Proc_pub_timer()
    {
        pub_timer += Time.deltaTime;
        if (pub_timer >= 1.0f) 
        {
            pub_flag = !pub_flag;
            if (pub_flag)
            {
                Start_SW();
                Start_timer1();
                Start_timer2();
            }
            else
            {
                Stop_SW();
                Stop_timer1();
                Stop_timer2();
            }
            pub_timer = 0.0f;
        }

    }

    private void Show_timer()
    {
        tM1.text = sW.ElapsedMilliseconds.ToString();
        tM2.text = timer1.ToString("F4");
        tM3.text = timer2.ToString("F4");
    }

    private void Start_SW()
    {
        sW.Start();
    }

    private void Process_SW()
    {

    }

    private void Stop_SW()
    {
        sW.Stop();
    }

    private void Start_timer1()
    {
        timer1_flag = true;
    }

    private void Stop_timer1()
    {
        timer1_flag = false;
    }

    private void Process_timer1()
    {
        if (timer1_flag) { timer1 += Time.deltaTime; }
        
    }

    private void Start_timer2()
    {
        StartCoroutine(Timer2());
    }

    private IEnumerator Timer2()
    {
        timer2_flag = true;
        yield return new WaitForSeconds(0);
        while(timer2_flag)
        {
            timer2 += Time.deltaTime;
            yield return null;
        }
    }

    private void Stop_timer2()
    {
        timer2_flag = false;
    }

    private void Process_RR()
    {
        tM4.text = (1.0f / Time.deltaTime).ToString("F4");
    }
}
