using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTest : MonoBehaviour {

    List<int> listtest2 = new List<int>();
    List<int> listtest3 = new List<int>();

    // Use this for initialization
    void Start () {

        List<int> listtest1 = new List<int>();

        listtest1.Add(1);
        listtest1.Add(2);
        listtest1.Add(3);
        listtest1.Add(4);
        listtest1.Add(5);
        listtest1.Add(6);
        listtest1.Add(7);
        listtest1.Add(8);
        listtest1.Add(9);

        foreach(int i in listtest1)
        {
            Debug.Log("int "+i);
        }

        //Debug.Log("out1 " + listtest1[9]);

        Debug.Log("capacity " + listtest1.Count);

        listtest2 = listtest1;  //pointer;

        Debug.Log("listtest2.count " + listtest2.Count);
        Debug.Log("listtest2[0] " + listtest2[0]);

        listtest1[3] = 100;

        Debug.Log("listtest2[3] " + listtest2[3]);

        listtest3 = new List<int>(listtest1);

        Debug.Log("listtest3.count " + listtest3.Count);
        Debug.Log("listtest3[0] " + listtest3[0]);

        listtest1[8] = 900;

        Debug.Log("listtest2[8] " + listtest3[8]);

        display_list(listtest3);

        List<float> listtest4 = new List<float>();

        listtest4.Add(1.5f);
        listtest4.Add(1.5f);
        listtest4.Add(1.5f);
        listtest4.Add(1.5f);


        display_list(listtest4);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void display_list(IEnumerable list)
    {
        int counter = 0;
        foreach (var element in list)
        {
            Debug.Log(" " + element + " " + counter);
            counter++;
        }
    }
}
