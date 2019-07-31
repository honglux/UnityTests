using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC : MonoBehaviour
{
    public static Vector3 NANVector3 = 
            new Vector3(float.MinValue, float.MinValue, float.MinValue);

    public Dictionary<MeshData,Transform> MD_TRANS_DICT { get; set; }

    public static RC IS { get; set; }

    private void Awake()
    {
        MD_TRANS_DICT = new Dictionary<MeshData, Transform>();

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
        MD_TRANS_DICT.Clear();
    }


}
