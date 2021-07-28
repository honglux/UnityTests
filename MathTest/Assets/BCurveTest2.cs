using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCurveTest2 : MonoBehaviour
{
    [SerializeField] private GameObject sphere;

    // Start is called before the first frame update
    void Start()
    {
        BCurveTest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BCurveTest()
    {
        Vector3 p0 = new Vector3(0.0f, 0.0f, 10.0f);
        Vector3 p2 = new Vector3(3.0f, 3.0f, 10.0f);
        Vector3 p1 = new Vector3(0.0f, 1.0f, 10.0f);
        Vector3 temp = new Vector3();
        for (float i = 0; i < 1; i += 0.1f) 
        {
            temp = p1 + Mathf.Pow((1 - i), 2) * (p0 - p1) + Mathf.Pow(i, 2)*(p2 - p1);
            Instantiate(sphere, temp, Quaternion.identity);
        }
    }
}
