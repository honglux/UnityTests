using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STController : MonoBehaviour
{
    public AudioSource AS;
    public AudioClip c1;
    public AudioClip c2;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1.0f)
        {

        }
    }
}
