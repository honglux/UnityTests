using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTParent : MonoBehaviour
{

    [SerializeField] private Camera Camera;
    [SerializeField] private Transform Left_TRANS;
    [SerializeField] private Transform Right_TRANS;
    [SerializeField] private Transform UP_TRANS;
    [SerializeField] private Transform Down_TRANS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Horizontal " + (Camera.WorldToScreenPoint(Left_TRANS.position) - Camera.WorldToScreenPoint(Right_TRANS.position)));
        Debug.Log("Vertical " + (Camera.WorldToScreenPoint(UP_TRANS.position) - Camera.WorldToScreenPoint(Down_TRANS.position)));
    }
}
