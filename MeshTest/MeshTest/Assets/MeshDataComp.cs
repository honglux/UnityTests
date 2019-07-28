using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDataComp : MonoBehaviour
{
    public MeshData mesh_data { get; set; }

    private void Awake()
    {
        mesh_data = new MeshData();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void set_MD(MeshData _mesh_data)
    {
        mesh_data = _mesh_data.clone();
    }
}
