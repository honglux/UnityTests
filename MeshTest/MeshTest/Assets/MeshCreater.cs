using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MeshCreater : MonoBehaviour
{
    public Material material;

    public static MeshCreater IS { get; set; }

    private void Awake()
    {
        IS = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        first_create_mesh();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void first_create_mesh()
    {
        
        Vector3[] uvs = new Vector3[] { new Vector3(-1.0f, 1.0f, 0.0f), new Vector3(1.0f, -1.0f, 0.0f) };
        List<Vector3> points = new List<Vector3>();
        points.Add(new Vector3(-1.0f, 1.0f, 0.0f));
        points.Add(new Vector3(1.0f, 1.0f, 0.0f));
        points.Add(new Vector3(-1.0f, -1.0f, 0.0f));
        points.Add(new Vector3(1.0f, -1.0f, 0.0f));
        create_mesh(points.ToArray(),uvs);
    }

    public void create_mesh(Vector3[] poss,Vector3[] init_UV)
    {
        MeshData mesh_data = new MeshData();
        mesh_data.set_init_UVs(init_UV[0],init_UV[1]);

        List<MeshPoint> verts = new List<MeshPoint>();
        foreach(Vector3 pos in poss)
        {
            verts.Add(new MeshPoint(pos, false));
        }
        mesh_data.Verticies = verts;
        mesh_data.MD_regener();

        create_mesh(mesh_data, true);
    }

    public Transform create_mesh(MeshData mesh_data, bool cal_uv)
    {
        if(cal_uv)
        {
            mesh_data.uv_cal_all();
        }

        Transform NM_TRANS = new GameObject("NewMesh").transform;
        Mesh mesh = new Mesh();
        mesh_data.to_mesh(ref mesh);
        MeshFilter MF = NM_TRANS.gameObject.AddComponent<MeshFilter>();
        MF.mesh = mesh;
        MF.mesh.RecalculateNormals();
        MeshRenderer MR = NM_TRANS.gameObject.AddComponent<MeshRenderer>();
        MR.material = material;
        MeshDataComp MDC = NM_TRANS.gameObject.AddComponent<MeshDataComp>();
        MDC.set_MD(mesh_data);

        RC.IS.MD_TRANS.Add(mesh_data, NM_TRANS);
        Debug.Log("mesh " + mesh_data.VarToString());

        return NM_TRANS;
    }
}
