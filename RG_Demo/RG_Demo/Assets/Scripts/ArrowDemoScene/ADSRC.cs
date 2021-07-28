using UnityEngine;

/// <summary>
/// Arrow Demo Scene Reference Controller;
/// </summary>
public class ADSRC : MonoBehaviour
{
    public static ADSRC IS { get; private set; }

    //Prefabs;
    public GameObject ArrowGroup_Prefab;
    //Tranforms;
    public Transform Canvas_TRANS;
    //Dynamic references;
    public ArrowGroup ArrowGroup_SCR { get; set; }  //Arrow Group script;

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
