using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_target : MonoBehaviour
{
    [SerializeField] public int a = 0;
    private string b = "abc";

    private Transform c = null;
    private GameObject d = null;

    private int prop {get;set;}

    private void Awake()
    {
        c = transform;
        d = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        b = "eee";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
