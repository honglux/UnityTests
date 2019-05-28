using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class PackageTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        byte[] p1 = Encoding.BigEndianUnicode.GetBytes("123");

        foreach(byte b in p1)
        {
            Debug.Log("p1 " + b.ToString());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
