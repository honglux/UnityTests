using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtcTanTest : MonoBehaviour
{
    public float x;
    public float y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ArcTan " + (Mathf.Atan2(y, x)*Mathf.Rad2Deg).ToString());
    }
}
