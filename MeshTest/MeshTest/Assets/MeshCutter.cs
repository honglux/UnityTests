using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCutter : MonoBehaviour
{
    [SerializeField] private MeshCreater MC_script;
    [SerializeField] private Vector3 CP1;
    [SerializeField] private Vector3 CP2;

    private Transform NM_TRANS;
    private Transform NC1_TRANS;
    private Transform NC2_TRANS;
    private Material material;

    private void Awake()
    {
        this.NM_TRANS = null;
        this.NC1_TRANS = null;
        this.NC2_TRANS = null;
        this.material = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            get_trans();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            cut();
        }
    }

    private void get_trans()
    {
        NM_TRANS = MC_script.NM_TRANS;
        material = NM_TRANS.GetComponent<MeshRenderer>().material;
        Debug.Log("NM_TRANS " + NM_TRANS.name);
    }

    private void cut()
    {
        MeshData mesh_data = new MeshData(NM_TRANS);
        MeshData NMD1 = mesh_data.clone();
        MeshData NMD2 = mesh_data.clone();

        NMD1.Verticies[1] = CP1;
        NMD1.Verticies[3] = CP2;
        NMD2.Verticies[0] = CP1;
        NMD2.Verticies[2] = CP2;
        NMD1.UVs[1] = new Vector2(0.0f, 1.0f - CP1.y);
        NMD1.UVs[3] = new Vector2(1.0f, 1.0f - CP2.y);
        NMD2.UVs[0] = new Vector2(0.0f, 1.0f - CP1.y);
        NMD2.UVs[2] = new Vector2(1.0f, 1.0f - CP2.y);

        mesh_debug(NMD1);
        mesh_debug(NMD2);

        NC1_TRANS = generate_new_mesh(NMD1, new Vector3(-2.0f, 0.0f, 0.0f), "NC1");
        NC1_TRANS = generate_new_mesh(NMD2, new Vector3(2.0f, 0.0f, 0.0f), "NC2");
    }

    private Transform generate_new_mesh(MeshData mesh_data,Vector3 pos,string name)
    {
        Mesh mesh = new Mesh();
        mesh_data.to_mesh(ref mesh);

        Transform NC_TRANS = (new GameObject(name)).transform;
        MeshFilter MF = NC_TRANS.gameObject.AddComponent<MeshFilter>();
        MeshRenderer MR = NC_TRANS.gameObject.AddComponent<MeshRenderer>();
        MF.mesh = mesh;
        NC_TRANS.position = pos;
        MR.material = material;
        return NC_TRANS;
    }

    private void mesh_debug(MeshData mesh_data)
    {
        Debug.Log(" " + mesh_data.VarToString());
    }
}
