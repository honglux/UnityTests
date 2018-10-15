using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class StringTest1 : MonoBehaviour {

    private static char[] file_spliter = new char[] { ' ', '\t' };
    private string path = "string_test1.txt";

    // Use this for initialization
    void Start () {
        Debug.Log("Loading game data file " + path);
        try
        {
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            { 
                string[] splitstr = reader.ReadLine().Split(file_spliter);
                if (splitstr[0][0] == '-')
                {
                    Debug.Log("splitstr[0][0]" + splitstr[0][0]);
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("Reading file error! " + e);
        }
        Debug.Log("Loading game data complete! ");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
