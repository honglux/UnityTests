using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceEqualTest : MonoBehaviour
{
    [SerializeField] private Transform child_TRANS;

    private ReferenceEqualTest rET_child;

    private void Awake()
    {
        if (child_TRANS != null) { rET_child = child_TRANS.GetComponent<ReferenceEqualTest>(); }
    }

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
        RET(this);
        if (rET_child != null)
        {
            rET_child.RET(rET_child);
            rET_child.RET(this);
        }
        
    }

    public void RET(ReferenceEqualTest _RET)
    {
        Debug.Log("RET " + System.Object.ReferenceEquals(_RET, this));
    }
}
