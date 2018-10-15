using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_Setting : MonoBehaviour {

    public GameObject Page1;
    public GameObject Page2;
    //public List<int> numbers;

    // Use this for initialization
    void Start () {
        Page1.SetActive(true);
        Page2.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void button1()
    {
        Debug.Log("Button1");
    }

    public void button2()
    {
        Debug.Log("Button12");
    }

    public void nextpage1()
    {
        Debug.Log("nextpage1");
        Page1.SetActive(false);
        Page2.SetActive(true);
    }

    public void nextpage2()
    {
        Debug.Log("nextpage2");
        Page1.SetActive(true);
        Page2.SetActive(false);
    }
}
