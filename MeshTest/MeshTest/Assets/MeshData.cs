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

    public MeshData()
    {
        this.Verticies = new List<MeshPoint>();
        this.Triangles = new List<int>();
        this.target_TRANS = null;
        //this.UVs = new List<Vector2>();
    }

    public MeshData(Transform _target_TRANS)
    {
        this.Verticies = new List<MeshPoint>();
        this.Triangles = new List<int>();
        this.target_TRANS = null;
        //this.UVs = new List<Vector2>();

        set_data(_target_TRANS);
    }

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

    public MeshData clone()
    {
        MeshData MD = new MeshData();
        MD.Verticies = new List<MeshPoint>(Verticies.Select(x => x.clone()));
        MD.Triangles = new List<int>(Triangles);
        MD.target_TRANS = this.target_TRANS;
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
