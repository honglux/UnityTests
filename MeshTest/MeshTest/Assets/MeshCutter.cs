using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MeshCutter : MonoBehaviour
{
    [SerializeField] private Vector3 CP1;
    [SerializeField] private Vector3 CP2;

    public static MeshCutter IS { get; set; }

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
        if (Input.GetKeyDown(KeyCode.S))
        {
            get_lines_Acut();
        }
    }

    private void get_lines_Acut()
    {
        Vector3 CP1_relative;
        Vector3 CP2_relative;
        Transform temp_TRANS;
        MeshLine cut_line;
        foreach (MeshData mesh_data in RC.IS.MD_TRANS_DICT.Keys.ToArray())
        {
            temp_TRANS = RC.IS.MD_TRANS_DICT[mesh_data];
            CP1_relative = CP1 - temp_TRANS.position;
            CP2_relative = CP2 - temp_TRANS.position;
            cut_line = new MeshLine();
            cut_line.line_cal(new MeshPoint(CP1_relative, true),
                                new MeshPoint(CP2_relative, true));
            cut_line.infinite = true;
            Debug.Log(cut_line.VarToString());
            if (cut(mesh_data, cut_line))
            {
                mesh_data.clean_destroy();
                Destroy(temp_TRANS.gameObject);
            }
        }
    }

    private bool cut(MeshData mesh_data, MeshLine cut_line)
    {
        MeshPoint[] cut_points = mesh_data.line_inter_cal(cut_line);
        
        if (cut_points.Length < 2)
        {
            return false;
        }

        MeshData[] cut_meshs = mesh_data.cut(cut_points[0], cut_points[1]);
        Transform NM1_TRANS = MeshCreater.IS.create_mesh(cut_meshs[0],false);
        Transform NM2_TRANS = MeshCreater.IS.create_mesh(cut_meshs[1],false);

        NM1_TRANS.position = new Vector3(-2.0f, 0.0f, 0.0f);
        NM2_TRANS.position = new Vector3(2.0f, 0.0f, 0.0f);

        return true;
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
}
