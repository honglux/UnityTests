using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonTest : MonoBehaviour
{
    [SerializeField] private string setting_path = ".";
    [SerializeField] private string setting_file_name = "a.json";

    private JJTTest jJTTest;

    // Start is called before the first frame update
    void Start()
    {
        jJTTest = new JJTTest();
        string json = JsonUtility.ToJson(jJTTest);
        if (!Directory.Exists(setting_path))
        {
            Directory.CreateDirectory(setting_path);
        }
        Debug.Log("Writing file " + setting_file_name + "!!!");
        File.WriteAllText(setting_path + setting_file_name, json);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
