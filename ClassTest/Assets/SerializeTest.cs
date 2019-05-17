using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SerializeTest : MonoBehaviour
{
    private byte[] mem_bytes;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            save_to_memory();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            pick_from_memory();
        }

        Debug.Log("mem_bytes " + mem_bytes.ToString());
    }

    private void save_to_memory()
    {
        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream MS = new MemoryStream();
        TestData TD = new TestData();
        TD.set_data(500);
        bf.Serialize(MS, TD);
        TestData TD1 = new TestData();
        bf.Serialize(MS, TD1);
        mem_bytes = MS.ToArray();
    }

    //Works!!!!!
    private void pick_from_memory()
    {
        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream MS = new MemoryStream(mem_bytes);
        TestData TD0 = bf.Deserialize(MS) as TestData;
        Debug.Log("TD0 " + TD0.test1);
        TestData TD1 = bf.Deserialize(MS) as TestData;
        Debug.Log("TD1 " + TD1.test1);
    }


}
