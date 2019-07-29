using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MeshCreater : MonoBehaviour
{
    [SerializeField] private Transform Target_TRANS;
    [SerializeField] private Material material;

    public Transform NM_TRANS { get; set; }

    private MeshData mesh_data;

    private void Awake()
    {
        this.mesh_data = new MeshData();
        this.NM_TRANS = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        create_mesh();

        //mesh_data.set_data(Target_TRANS);
        //mesh_data = change_mesh(mesh_data);
        //clone_mesh();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void clone_mesh()
    //{
    //    Transform clone_TRANS = new GameObject("MeshClone").transform;
    //    Mesh mesh = new Mesh();
    //    //mesh.vertices = mesh_data.Verticies.ToArray();
    //    mesh.triangles = mesh_data.Triangles.ToArray();
    //    mesh.UploadMeshData(true);
    //    MeshFilter MF = clone_TRANS.gameObject.AddComponent<MeshFilter>();
    //    MF.mesh = mesh;
    //    MeshRenderer MR = clone_TRANS.gameObject.AddComponent<MeshRenderer>();
    //    clone_TRANS.position = new Vector3(3.0f, 3.0f, 3.0f);
    //}

    //private MeshData change_mesh(MeshData MD)
    //{
    //    Vector3 V0 = MD.Verticies[0];
    //    MD.Verticies[0] = new Vector3(V0.x / 2.0f, V0.y / 2.0f, V0.z / 2.0f);
    //    return MD;
    //}

    private void create_mesh()
    {
        List<Vector3> temp_LV3 = new List<Vector3>();
        temp_LV3.Add(new Vector3(0.0f, 0.0f, 0.0f));
        temp_LV3.Add(new Vector3(0.0f, 1.0f, 0.0f));
        temp_LV3.Add(new Vector3(1.0f, 0.0f, 0.0f));
        temp_LV3.Add(new Vector3(1.0f, 1.0f, 0.0f));
        List<Vector2> UVs = new List<Vector2>();
        UVs.Add(new Vector2(0.0f, 1.0f));
        UVs.Add(new Vector2(0.0f, 0.0f));
        UVs.Add(new Vector2(1.0f, 1.0f));
        UVs.Add(new Vector2(1.0f, 0.0f));
        mesh_data.Verticies = MeshPoint.FromVec3(temp_LV3, UVs);
        mesh_data.Triangles = (new int[]
            { 0, 1, 2,
                1, 3, 2
            }).ToList<int>();
        mesh_data.set_init_UVs(temp_LV3[1], temp_LV3[2]);

        NM_TRANS = new GameObject("NewMesh").transform;
        Mesh mesh = new Mesh();
        mesh_data.to_mesh(ref mesh);
        MeshFilter MF = NM_TRANS.gameObject.AddComponent<MeshFilter>();
        MF.mesh = mesh;
        MeshRenderer MR = NM_TRANS.gameObject.AddComponent<MeshRenderer>();
        MR.material = material;
        MeshDataComp MDC = NM_TRANS.gameObject.AddComponent<MeshDataComp>();
        MDC.set_MD(mesh_data);
    }

    private void load_material()
    {
        material = Resources.Load("Material/Night_Sky.mat", typeof(Material)) as Material;
    }
}
