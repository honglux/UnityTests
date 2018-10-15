using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

        ////not reference;
        //ListTestClass listTestClass = new ListTestClass();
        //List<ListTestClass> list = new List<ListTestClass>();
        //for (int i = 0; i < 10; i++)
        //{
        //    listTestClass = new ListTestClass();
        //    listTestClass.test1 = i;
        //    list.Add(listTestClass);
        //}
        //foreach (ListTestClass LTC in list)
        //{
        //    Debug.Log("LTC.test1" + LTC.test1);
        //}


        ////not clone;
        //List<ListTestClass> list2 = list;
        //list2[5].test1 = 999;
        //foreach (ListTestClass LTC in list2)
        //{
        //    Debug.Log("list2.test1" + LTC.test1);
        //}
        //foreach (ListTestClass LTC in list)
        //{
        //    Debug.Log("list12.test1" + LTC.test1);
        //}

        ////not clone;
        //List<ListTestClass> list3 = new List<ListTestClass>(list);
        //foreach (ListTestClass LTC3 in list3)
        //{
        //    LTC3.test1 = 333;
        //    Debug.Log("list3.test1" + LTC3.test1);
        //}
        //foreach (ListTestClass LTC1 in list)
        //{
        //    Debug.Log("list13.test1" + LTC1.test1);
        //}

        ////clone!!!!!!!!!!!!!!!!!!!!!!!
        //List<int> list4 = new List<int>();
        //for (int i = 0; i < 10; i++)
        //{
        //    list4.Add(i);
        //}
        //List<int> list5 = new List<int>(list4);
        //list5[5] = 999;
        //foreach (int LTC5 in list5)
        //{
        //    Debug.Log("list5" + LTC5);
        //}
        //foreach (int LTC4 in list4)
        //{
        //    Debug.Log("list4" + LTC4);
        //}

    }

    // Update is called once per frame
    void Update () {
		
	}
}
