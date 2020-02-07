using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildClassCallTest : MonoBehaviour
{
    [SerializeField] private Parent2ClassTest P2CT;

    // Start is called before the first frame update
    void Start()
    {
        P2CT.test_func2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
