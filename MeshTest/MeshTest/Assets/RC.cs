using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC : MonoBehaviour
{
    public Dictionary<MeshData,Transform> MD_TRANS { get; set; }

    public static RC IS { get; set; }

    private void Awake()
    {
        MD_TRANS = new Dictionary<MeshData, Transform>();

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

    public void clear_MD()
    {
        MD_TRANS.Clear();
    }


}
