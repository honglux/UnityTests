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
    public Dictionary<int, Transform> ChestGroup_TRANS_dict { get; private set; }
         
    private void Awake()
    {
        IS = this;

        ChestGroup_TRANS_dict = new Dictionary<int, Transform>();
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
