using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonTest : MonoBehaviour
{
    const string file = "JsonTest.json";

    // Start is called before the first frame update
    void Start()
    {
        read();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void write()
    {
        Json_TTest tests = new Json_TTest();
        string tests_json = JsonUtility.ToJson(tests);
        File.WriteAllText(file, tests_json);
    }

    private void read()
    {
        string json_str = File.ReadAllText(file);
        Json_TTest result = JsonUtility.FromJson<Json_TTest>(json_str);
        Debug.Log("test3 "+(result.test3 == enum_test.b));
    }
}
