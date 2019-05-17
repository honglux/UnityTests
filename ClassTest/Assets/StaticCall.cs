using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCall : MonoBehaviour
{
    float timer = 0.0f;

    List<IEnumerator> inst_list;

    //IEnumerator inst1 = StaticClassTest.IEstatic_test(1);
    //IEnumerator inst2 = StaticClassTest.IEstatic_test(2);
    //IEnumerator inst3 = StaticClassTest.IEstatic_test(3);

    private void Awake()
    {
        Debug.Log("static a " + StaticClassTest.a);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.inst_list = new List<IEnumerator>();
        add_insts();

        foreach(IEnumerator inst in inst_list)
        {
            StartCoroutine(inst);
        }
        //StartCoroutine(inst1);
        //StartCoroutine(inst2);
        //StartCoroutine(inst3);


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 5.0f)
        {
            foreach (IEnumerator inst in inst_list)
            {
                StopCoroutine(inst);
            }
            timer = -9999;
        }
    }

    void add_insts()
    {
        inst_list.Add(StaticClassTest.IEstatic_test(1));
        inst_list.Add(StaticClassTest.IEstatic_test(2));
        inst_list.Add(StaticClassTest.IEstatic_test(3));
    }

}
