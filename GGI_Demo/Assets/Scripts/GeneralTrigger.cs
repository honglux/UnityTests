using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralTrigger : MonoBehaviour
{
    [SerializeField] private Transform root_TRANS;
    
    public Transform Get_root_TRANS()
    {
        return root_TRANS;
    }
}
