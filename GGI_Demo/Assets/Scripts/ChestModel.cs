using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestModel : MonoBehaviour
{
    [SerializeField] private Animator chest_animator;

    /// <summary>
    /// Open the chest model;
    /// </summary>
    public void OpenChest()
    {
        chest_animator.SetTrigger(SD.AniChestOpenTrigger);
    }

    /// <summary>
    /// Close the chest model;
    /// </summary>
    public void CloseChest()
    {
        chest_animator.SetTrigger(SD.AniChestCloseTrigger);
    }
}
