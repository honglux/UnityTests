using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeTest : MonoBehaviour
{
    [SerializeField] private GameObject aT_prefab;
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
        AwakeTarget aT = Instantiate(aT_prefab).GetComponent<AwakeTarget>();
        aT.test1();
    }
}
