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
    private MeshLine mesh_line;

    private void Awake()
    {
        this.NM_TRANS = null;
        this.NC1_TRANS = null;
        this.NC2_TRANS = null;
        this.material = null;
        this.mesh_line = new MeshLine();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
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
        MeshData mesh_data = NM_TRANS.GetComponent<MeshDataComp>().mesh_data;

        MeshPoint CMP1 = new MeshPoint(CP1, true);
        MeshPoint CMP2 = new MeshPoint(CP2, true);
        get_cut_line(CMP1, CMP2);
        CMP1.uv_cal(mesh_data);
        CMP2.uv_cal(mesh_data);

        List<MeshPoint> FHalf;
        List<MeshPoint> SHalf;
        points_cal(mesh_data.Verticies, mesh_line, CMP1, CMP2, out FHalf, out SHalf);

        MeshData NMD1 = new MeshData();
        MeshData NMD2 = new MeshData();

        NMD1.Verticies = FHalf;
        NMD2.Verticies = SHalf;

        mesh_debug(NMD1);
        mesh_debug(NMD2);

        NMD1 = MD_regener(NMD1);
        NMD2 = MD_regener(NMD2);

        generate_new_mesh(NMD1, new Vector3(-2.0f, 0.0f, 0.0f), "NC1");
        generate_new_mesh(NMD2, new Vector3(2.0f, 0.0f, 0.0f), "NC2");

        //NMD1.Verticies[1].pos = CP1;
        //NMD1.Verticies[3].pos = CP2;
        //NMD2.Verticies[0].pos = CP1;
        //NMD2.Verticies[2].pos = CP2;
        //NMD1.Verticies[1].uv = new Vector2(0.0f, 1.0f - CP1.y);
        //NMD1.Verticies[3].uv = new Vector2(1.0f, 1.0f - CP2.y);
        //NMD2.Verticies[0].uv = new Vector2(0.0f, 1.0f - CP1.y);
        //NMD2.Verticies[2].uv = new Vector2(1.0f, 1.0f - CP2.y);

        //mesh_debug(NMD1);
        //mesh_debug(NMD2);

        //NC1_TRANS = generate_new_mesh(NMD1, new Vector3(-2.0f, 0.0f, 0.0f), "NC1");
        //NC1_TRANS = generate_new_mesh(NMD2, new Vector3(2.0f, 0.0f, 0.0f), "NC2");
    }

    private MeshData MD_regener(MeshData MD)
    {
        MD.MD_regener();
        return MD;
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

    private void mesh_debug(List<MeshPoint> list_MP, bool FHalf)
    {
        foreach(MeshPoint MP in list_MP)
        {
            if(FHalf)
            {
                Transform temp_TRANS = 
                    GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
                temp_TRANS.position = MP.to_v3();
                temp_TRANS.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
            else
            {
                Transform temp_TRANS =
                    GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
                temp_TRANS.position = MP.to_v3();
                temp_TRANS.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
        }
    }

    private void get_cut_line(MeshPoint p1, MeshPoint p2)
    {
        mesh_line.line_cal(p1, p2);
    }

    private void points_cal(List<MeshPoint> verticies, MeshLine cut_line,
                            MeshPoint p1, MeshPoint p2,
                            out List<MeshPoint> Fhalf, out List<MeshPoint> Shalf)
    {
        Fhalf = new List<MeshPoint>();
        Shalf = new List<MeshPoint>();

        MeshPoint MP;
        foreach(MeshPoint vert in verticies)
        {
            int pos_cal = cut_line.position_cal(vert);
            if (pos_cal == 1)
            {
                Fhalf.Add(vert);
            }
            else if(pos_cal == 0)
            {
                MP = vert.clone();
                Fhalf.Add(MP);
                Shalf.Add(vert);
            }
            else
            {
                Shalf.Add(vert);
            }
        }
        MeshPoint p1C = p1.clone();
        MeshPoint p2C = p2.clone();
        Fhalf.Add(p1C);
        Fhalf.Add(p2C);
        Shalf.Add(p1);
        Shalf.Add(p2);
    }
}
