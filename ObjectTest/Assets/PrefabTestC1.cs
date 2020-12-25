using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTestC1 : MonoBehaviour, PrefabTestIF
{
    [SerializeField] private int a;
    [SerializeField] private int b;

    public GameObject Get_GO()
    {
        return gameObject;
    }

    public void PrintA()
    {
        Debug.Log(a);
    }

    public void PrintB()
    {
        Debug.Log(b);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
