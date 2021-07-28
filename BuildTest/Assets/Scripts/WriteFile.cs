using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WriteFile : MonoBehaviour
{
    public string path;
    public float timeInterval;

    private StreamWriter file;

    private int counter;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        timer = Time.time + timeInterval;

        create_file();
    }

    private void FixedUpdate()
    {
        if (Time.time > timer)
        {
            timer = Time.time + timeInterval;
            update_file();
        }
    }

    private void create_file()
    {
        if (!File.Exists(path))
        {
            file = new StreamWriter(path);
        }
        else
        {
            file = File.AppendText(path);
        }
    }

    private void update_file()
    {
        if (file == null) { return; }
        file.WriteLine(counter.ToString());
        ++counter;
    }

    private void OnApplicationQuit()
    {
        file.Close();
    }
}
