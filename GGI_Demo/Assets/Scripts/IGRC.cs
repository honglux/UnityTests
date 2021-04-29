using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Reference controller in InGameScene;
/// </summary>
public class IGRC : MonoBehaviour
{

    public static IGRC IS;

    [Header("In editor reference")]
    public Camera MainCamera;
    public ChestBGTemplate CBGTemplate; //Template reference;
    public Transform ChestGroup_parent; //Parent transform of the chest groups;
    [Header("Prefabs")]
    public GameObject ChestGroup_PRE;   //Chest group prefabs;

    //Runtime reference;
    public Dictionary<int, Transform> ChestGroup_TRANS_dict { get; private set; }   //References of the chest groups;
         
    private void Awake()
    {
        IS = this;

        ChestGroup_TRANS_dict = new Dictionary<int, Transform>();
    }
}
