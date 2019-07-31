using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MeshCutter : MonoBehaviour
{
    [SerializeField] private Vector3 CP1;
    [SerializeField] private Vector3 CP2;

    public static MeshCutter IS;
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
            cut();
        }
    }

    private void cut()
    {
        MeshData mesh_data = (RC.IS.MD_TRANS.Keys).First();

        Vector3 pos = RC.IS.MD_TRANS[mesh_data].transform.position;
        CP1 -= pos;
        CP2 -= pos;

        MeshPoint CMP1 = new MeshPoint(CP1, true);
        MeshPoint CMP2 = new MeshPoint(CP2, true);

        MeshData[] cut_meshs = mesh_data.cut(CMP1,CMP2);

        Transform NM1_TRANS = MeshCreater.IS.create_mesh(cut_meshs[0],false);
        Transform NM2_TRANS = MeshCreater.IS.create_mesh(cut_meshs[1],false);

        NM1_TRANS.position = new Vector3(-2.0f, 0.0f, 0.0f);
        NM2_TRANS.position = new Vector3(2.0f, 0.0f, 0.0f);

        mesh_data.clean_destroy();
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
