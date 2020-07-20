using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefTest : MonoBehaviour
{
    [SerializeField] private Transform Text_TRANS;

    private string ref_test;

    private float ref_test2;

    private void Awake()
    {
        new RefClass1();
        ref_test2 = RefClass1.IS.ref_test2; //Not possibile;
    }

    // Start is called before the first frame update
    void Start()
    {
        //ref string ref_test = ref Text_TRANS.GetComponent<TextMesh>().text;   //Not Supportted;

        ref_test = "aaaaaaaaaaaaaa";

        RefClass1 RC1 = new RefClass1();
        RC1.C_RC2();

    }

    // Update is called once per frame
    void Update()
    {
        //RefClass1.IS.up_RF2();
        //Debug.Log("ref_test2 " + ref_test2.ToString());
    }

    private void test(ref string a)
    {
        a = "aaaaaaaaaaaaaa";
    }
}
