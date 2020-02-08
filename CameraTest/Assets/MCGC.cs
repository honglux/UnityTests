using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCGC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Display.displays.Length == 2)
        {
            Display.displays[1].Activate();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
