using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashSetTest : MonoBehaviour
{
    [SerializeField] private Transform a_TRANS;
    [SerializeField] private Transform b_TRANS;
    [SerializeField] private Transform c_TRANS;

    HashSet<Transform> a;

    private void Awake()
    {
        a = new HashSet<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        test1();
    }

    // Update is called once per frame
    void Update()
    {
        test1();
    }

    private void test1()
    {
        
        Debug.Log(a.Count);
        a.Add(a_TRANS);
        Debug.Log(a.Count);
        a.Add(b_TRANS);
        Debug.Log(a.Count);
        a.Add(c_TRANS);
        Debug.Log(a.Count);

    }
}
