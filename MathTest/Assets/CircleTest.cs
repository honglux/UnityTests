using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CircleTest : MonoBehaviour
{
    [SerializeField] private GameObject Dot_Prefab;

    [SerializeField] private float Radius = 5.0f;
    [SerializeField] private float DegreeIncrease = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        draw_circle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void draw_circle()
    {
        float degree = 0.0f;
        float x = 0.0f;
        float y = 0.0f;
        while(degree < 360)
        {
            //radians;
            //x = Radius * Mathf.Cos(degree);
            //y = Radius * Mathf.Sin(degree);
            //also radians;
            x = Radius * (float)Math.Cos(Math.PI * degree / 180.0);
            y = Radius * (float)Math.Sin(Math.PI * degree / 180.0);
            GameObject obj = Instantiate(Dot_Prefab, new Vector3(x, y, 10.0f), Quaternion.identity);
            obj.GetComponent<dot>().degrees = degree;
            degree += DegreeIncrease;
        }
    }

}
