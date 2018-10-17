using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject DLPrefab;
    public GameObject ObjectPrefab;

    public Text CounterText;

    public int InstanCounter = 0;
    public float WaitTime = 1.0f;

    private bool wait_flag;
    private float wait_timer;

    private Animator GCAnimator;

	// Use this for initialization
	void Start () {
        this.wait_flag = false;
        this.wait_timer = WaitTime;
        this.GCAnimator = GetComponent<Animator>();

        for (int i = 0; i < InstanCounter; i++)
        {
            intant_objects();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
        if(wait_flag)
        {
            wait_timer -= Time.deltaTime;
        }

        CounterText.text = "Counter: " + InstanCounter.ToString();

	}

    public void ToInstantiate()
    {
        intant_objects();
        InstanCounter++;
        GCAnimator.SetTrigger("NextStep");
    }

    public void ToWait()
    {
        wait_flag = true;
    }

    public void Wait()
    {
        if(wait_timer < 0.0f)
        {
            wait_timer = WaitTime;
            GCAnimator.SetTrigger("NextStep");
            wait_flag = false;
        }
    }

    private void intant_objects()
    {
        Instantiate(DLPrefab,
            new Vector3(Random.Range(-50.0f, 50.0f),
                            Random.Range(-50.0f, 50.0f),
                            Random.Range(0.0f, 100.0f)),
            new Quaternion());

        Instantiate(ObjectPrefab,
            new Vector3(Random.Range(-50.0f, 50.0f),
                            Random.Range(-50.0f, 50.0f),
                            Random.Range(0.0f, 100.0f)),
            new Quaternion());
    }
}
