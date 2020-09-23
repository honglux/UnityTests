using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Test : MonoBehaviour
{
    private const string path = "/sdcard/Download/1.txt";

    [SerializeField] private TextMesh TM;

    // Start is called before the first frame update
    void Start()
    {
        TM.text = load_setting(path);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string load_setting(string path)
    {
        try
        {
            string from_json = File.ReadAllText(path);
            return from_json;
        }
        catch (Exception e) 
        {
            Debug.Log("Reading settings error " + e); 
            return e.ToString();
        }
    }

    private void test1()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("Do something special here!");
        }
    }
}
