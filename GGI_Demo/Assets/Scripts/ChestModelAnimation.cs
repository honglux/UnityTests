using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to control the chest aniamtion call back;
/// </summary>
public class ChestModelAnimation : MonoBehaviour
{
    [SerializeField] private ChestGroup chest_group;
    
    public void Open_chest_callback()
    {
        chest_group.OpenChest_callback();
    }

    public void Close_chest_callback()
    {
        chest_group.CloseChest_callback();
    }
}
