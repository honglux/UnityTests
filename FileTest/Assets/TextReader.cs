using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class TextReader : MonoBehaviour {

    const string path = "Assets/test1.txt";

    StreamReader reader2;

    string[] splitstr;

    int counter;

    // Use this for initialization
    void Start () {
        //ReadString();

        this.reader2 = new StreamReader(path);
        this.counter = 0;

        while (!reader2.EndOfStream)
        {
            string line = reader2.ReadLine();
            Debug.Log("line " + counter + " : " + line);
            counter++;
            try
            {
                int lineint = int.Parse(line);
                //Debug.Log("int+1 " + (lineint + 1));
                
            }
            catch (Exception e)
            {

            }
            try
            {
                splitstr = line.Split(new char[] { ' ', '\t' });
                Debug.Log("splitstr " + splitstr.Length);
                Debug.Log("splitstr[0] " + splitstr[0]);
                Debug.Log("splitstr[0] " + splitstr[1]);
            }
            catch(Exception e)
            {

            }

        }
    }
	
	// Update is called once per frame
	void Update () {


	}

    static void ReadString()
    {
        string path = "Assets/test1.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }

}
