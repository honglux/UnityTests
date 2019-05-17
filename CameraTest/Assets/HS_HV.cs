using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HS_HV : MonoBehaviour
{
    public enum TargetType { Horizontal, Vertical, HNV }

    public TargetType CurrTargetType;
    //public OringinalHS OHS_script;
    public Transform Oringinal_TRANS;
    public Vector3 Hit_pos;
    public LayerMask RayCastMask;
    public Transform Target_TRANS;

    private RaycastHit[] raycastHit;

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
                transform.localEulerAngles = 
                    new Vector3(0.0f, Oringinal_TRANS.eulerAngles.y, 0.0f);
                break;
            case TargetType.Vertical:
                transform.localEulerAngles = 
                    new Vector3(Oringinal_TRANS.eulerAngles.x, 0.0f, 0.0f);
                break;
            case TargetType.HNV:
                transform.localEulerAngles = Oringinal_TRANS.eulerAngles;
                break;
        }

        Target_TRANS.position = Hit_pos;
    }

    private void FixedUpdate()
    {
        raycast();
    }

    private void raycast()
    {
        
        raycastHit = 
            Physics.RaycastAll(transform.position, transform.forward, 100.0f, RayCastMask);
        foreach(RaycastHit hit in raycastHit)
        {
            if (hit.transform.CompareTag("Block"))
            {
                Hit_pos = hit.point;
            }
        }
    }
}
