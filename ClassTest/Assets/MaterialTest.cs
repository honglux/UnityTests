using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Shader.Find("Transparent/Bumped Diffuse"));
        create();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void create()
    {
        GameObject test = GameObject.CreatePrimitive(PrimitiveType.Cube);
        test.GetComponent<Renderer>().material = new Material(Shader.Find("Transparent/Diffuse"));
        test.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 0.1f);
        test.transform.position = new Vector3(0.0f, 0.0f, 10.0f);
    }
}
