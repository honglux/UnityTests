using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ListTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //not reference;
        ListTestClass listTestClass = new ListTestClass();
        List<ListTestClass> list = new List<ListTestClass>();
        for (int i = 0; i < 10; i++)
        {
            listTestClass = new ListTestClass();
            listTestClass.test1 = i;
            list.Add(listTestClass);
        }
        foreach (ListTestClass LTC in list)
        {
            Debug.Log("LTC.test1" + LTC.test1);
        }


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

        //clone!!!!!!!!
        List<ListTestClass> list5 = new List<ListTestClass>(list.Select(x => x.clone()));

        //List<Transform> obj_list = new List<Transform>();
        //Transform obj1 = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        //Transform obj2 = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
        //Transform obj3 = GameObject.CreatePrimitive(PrimitiveType.Cylinder).transform;
        //obj_list.Add(obj1);
        //obj_list.Add(obj2);
        //obj_list.Add(obj3);
        //obj_list.Remove(obj2);
        //Debug.Log("obj_list length " + obj_list.Count);
        //foreach(Transform obj in obj_list)
        //{
        //    Debug.Log("obj " + obj.name);
        //}
    }

    // Update is called once per frame
    void Update () {
		
	}
}
