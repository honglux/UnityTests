using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController3 : MonoBehaviour {

    private const string BTPath = "BinaryTest.dat";

    private string trialLogFile;

    private StringBuilder log_string = new StringBuilder();
    private int counter = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        counter++;
        log_string.Append(counter.ToString() + " ");
        if(counter%3 == 0)
        {
            log_string.AppendLine();
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            write_file();
        }

        //Debug.Log("counter " + counter);
	}

    private void write_file()
    {
        StreamWriter file;
        try
        {

            // create log file if it does not already exist. Otherwise open it for appending new trial
            if (!File.Exists(trialLogFile))
            {
                trialLogFile = "Log/trialLog_" + 
                            String.Format("{0:_yyyy_MM_dd_hh_mm_ss}", DateTime.Now) + ".txt";
                file = new StreamWriter(trialLogFile);
                file.WriteLine("A\tB\tC");
            }
            else
            {
                file = File.AppendText(trialLogFile);
            }

            file.WriteLine(log_string+" clicked here!!!!!!!! ");
            file.Close();
            log_string = new StringBuilder();
        }
        catch (System.Exception e)
        {
            Debug.Log("Error in accessing file: " + e);
        }

    }

    public void binary_save()
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs;
        if (!File.Exists(BTPath))
        {
            fs = File.Open(BTPath, FileMode.Create);
        }
        else
        {
            fs = File.Open(BTPath, FileMode.Open);
        }

        DataClass dataClass = new DataClass();
        dataClass.test2 = Int32.MaxValue;
        dataClass.test4 = Int32.MaxValue.ToString();

        bf.Serialize(fs, dataClass);
        fs.Close();

    }

    public void binary_load()
    {
        if (File.Exists(BTPath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(BTPath, FileMode.Open);

            DataClass dataClass = (DataClass)bf.Deserialize(fs);

            fs.Close();

            Debug.Log("dataClass "+dataClass.test1+ dataClass.test2+ dataClass.test3+ dataClass.test4);
        }
    }

}
