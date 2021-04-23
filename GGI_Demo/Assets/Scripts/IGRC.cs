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
    [Header("Prefabs")]
    public GameObject ChestGroup_PRE;

    //Runtime reference;
    public List<Transform> ChestGroup_TRANS_list;
         
    private void Awake()
    {
        IS = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
