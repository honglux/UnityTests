using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefTest : MonoBehaviour
{
    [SerializeField] private Transform Text_TRANS;

    private string ref_test;

    // Start is called before the first frame update
    void Start()
    {
        //ref string ref_test = ref Text_TRANS.GetComponent<TextMesh>().text;   //Not Supportted;

        ref_test = "aaaaaaaaaaaaaa";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void test(ref string a)
    {
        a = "aaaaaaaaaaaaaa";
    }
}
