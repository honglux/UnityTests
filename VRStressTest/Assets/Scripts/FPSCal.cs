using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCal : MonoBehaviour {

    public Text fps_text;

    private float deltaTime = 0.0f;

    private string fps_init_str = "FPS: ";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fps_text.text = fps_init_str + fps.ToString("F2");
    }
}
