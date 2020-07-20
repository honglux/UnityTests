using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentInstanceTest : MonoBehaviour
{
    public int abc;

    public static ParentInstanceTest IS { get; set; }

    private void Awake()
    {
        IS = this;

        this.abc = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void test1()
    {
        abc += 1;
        Debug.Log("test1 "+ abc.ToString());
    }
}
