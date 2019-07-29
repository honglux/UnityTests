using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MeshData
{
    public List<MeshPoint> Verticies { get; set; }
    public List<int> Triangles { get; set; }
    //public List<Vector2> UVs { get; set; }
    public Transform target_TRANS { get; set; }
    public Vector2 center_pos { get; set; }
    public Vector2[] UV_poss { get; set; }

    public MeshData()
    {
        this.Verticies = new List<MeshPoint>();
        this.Triangles = new List<int>();
        this.target_TRANS = null;
        //this.UVs = new List<Vector2>();
        this.center_pos = new Vector2();
        this.UV_poss = new Vector2[2];
    }

    //public MeshData(Transform _target_TRANS)
    //{
    //    this.Verticies = new List<MeshPoint>();
    //    this.Triangles = new List<int>();
    //    this.target_TRANS = null;
    //    this.center_pos = new Vector2();
    //    this.UV_poss = new Vector2[2];
    //    //this.UVs = new List<Vector2>();

    //    set_data(_target_TRANS);
    //}

    public void set_data(Transform _target_TRANS)
    {
        target_TRANS = _target_TRANS;
        Mesh mesh = target_TRANS.GetComponent<MeshFilter>().mesh;
        Verticies = MeshPoint.FromVec3(mesh.vertices.ToList<Vector3>());
        Triangles = mesh.triangles.ToList<int>();
        //UVs = mesh.uv.ToList<Vector2>();
    }

    //public void set_data(Vector3[] _verticies,int[] _triangles,Vector2[] _UVs)
    //{
    //    Verticies = _verticies.ToList<Vector3>();
    //    Triangles = _triangles.ToList<int>();
    //    UVs = _UVs.ToList<Vector2>();
    //}

    public void set_init_UVs(Vector3 UL,Vector3 DR)
    {
        UV_poss[0] = (Vector2)UL;
        UV_poss[1] = (Vector2)DR;
    }
    
    public void uv_cal(ref MeshPoint MP)
    {
        float x = MP.pos.x - UV_poss[0].x;
        float y = MP.pos.y - UV_poss[0].y;
        float range_x = UV_poss[1].x - UV_poss[0].x;
        float range_y = UV_poss[1].y - UV_poss[0].y;
        float uv_x = x / range_x;
        float uv_y = y / range_y;
        MP.uv = new Vector2(uv_x, uv_y);
    }

    public void to_mesh(ref Mesh mesh)
    {
        List<Vector2> UVs;
        List<Vector3> V_pos;
        MeshPoint.SepLists(Verticies, out V_pos, out UVs);

        mesh.vertices = V_pos.ToArray();
        mesh.triangles = Triangles.ToArray();
        mesh.uv = UVs.ToArray();
        //mesh.UploadMeshData(false);
    }

    public void MD_regener()
    {
        center_cal();
        sort_vert();
    }

    public void center_cal()
    {
        float ave_x = 0.0f;
        float ave_y = 0.0f;
        foreach (MeshPoint poi in Verticies)
        {
            ave_x += poi.pos.x;
            ave_y += poi.pos.y;
        }
        center_pos = new Vector2(ave_x / (float)Verticies.Count, 
                                    ave_y / (float)Verticies.Count);
    }

    public void sort_vert()
    {
        Triangles = new List<int>();
        Verticies.Sort((x, y) => x.CompareTo(y, center_pos));
        Triangles = tria_regener(Verticies.Count);
    }

    public void set_UVs()
    {
        foreach(MeshPoint MP in Verticies)
        {
            MP.uv = new Vector2();
        }
    }

    private List<int> tria_regener(int number)
    {
        List<int> triangles = new List<int>();
        for(int i = 1;i<number - 1;i++)
        {
            triangles.Add(0);
            triangles.Add(i);
            triangles.Add(i + 1);
        }
        return triangles;
    }

    public MeshData clone()
    {
        MeshData MD = new MeshData();
        MD.Verticies = new List<MeshPoint>(Verticies.Select(x => x.clone()));
        MD.Triangles = new List<int>(Triangles);
        MD.target_TRANS = this.target_TRANS;
        MD.UV_poss = UV_poss;
        return MD;
    }

    public string VarToString()
    {
        string result = "";

        foreach (MeshPoint vert in Verticies)
        {
            result += " " + vert.VarToString();
        }
        result += " \n";
        foreach (int tria in Triangles)
        {
            result += " " + tria.ToString();
        }
        result += " \n";

        return result;
    }

}
