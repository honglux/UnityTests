using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDebug : MonoBehaviour
{
    [SerializeField] private Transform Target_TRANS;

    private MeshFilter target_MF;

    // Start is called before the first frame update
    void Start()
    {
        debug_target();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void debug_target()
    {
        target_MF = Target_TRANS.GetComponent<MeshFilter>();
        Mesh mesh = target_MF.mesh;
        int iter = 0;
        foreach (Vector3 vert in mesh.vertices)
        {
            Debug.Log("vert " + iter + " " + vert);
            iter++;
        }
        iter = 0;
        foreach(int tran in mesh.triangles)
        {
            Debug.Log("tran " + iter + " " + tran);
            iter++;
        }
    }
}
