using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    [SerializeField] private string address;

    // Start is called before the first frame update
    void Start()
    {
        test1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void test1()
    {
        GameObject.Instantiate(Resources.Load(address), new Vector3(0.0f, 0.0f, 10.0f), Quaternion.identity);
    }
}
