using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash2 : MonoBehaviour
{
    private Animation ani;

    private void Awake()
    {
        ani = GetComponent<Animation>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ani");
        ani.Play("Splash2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
