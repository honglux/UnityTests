using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestGroupTrigger : MonoBehaviour
{
    [SerializeField] private Transform root_TRANS;

    /// <summary>
    /// Get the root script;
    /// </summary>
    /// <returns></returns>
    public Transform Get_root_CG()
    {
        return root_TRANS;
    }
}
