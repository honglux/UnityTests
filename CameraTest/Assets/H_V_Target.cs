using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_V_Target : MonoBehaviour
{
    public enum TargetType { Horizontal,Vertical,HNV}

    public TargetType CurrTargetType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(CurrTargetType)
        {
            case TargetType.Horizontal:
                transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
                break;

            case TargetType.Vertical:
                transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
                break;
        }

        transform.rotation = Quaternion.identity;
    }
}
