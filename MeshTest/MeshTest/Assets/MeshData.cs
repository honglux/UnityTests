using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MeshData
{
    public List<Vector3> Verticies { get; set; }
    public List<int> Triangles { get; set; }
    public List<Vector2> UVs { get; set; }
    public Transform target_TRANS { get; set; }

    public MeshData()
    {
        this.Verticies = new List<Vector3>();
        this.Triangles = new List<int>();
        this.target_TRANS = null;
        this.UVs = new List<Vector2>();
    }

    public MeshData(Transform _target_TRANS)
    {
        this.Verticies = new List<Vector3>();
        this.Triangles = new List<int>();
        this.target_TRANS = null;
        this.UVs = new List<Vector2>();

        set_data(_target_TRANS);
    }

    public void set_data(Transform _target_TRANS)
    {
        target_TRANS = _target_TRANS;
        Mesh mesh = target_TRANS.GetComponent<MeshFilter>().mesh;
        Verticies = mesh.vertices.ToList<Vector3>();
        Triangles = mesh.triangles.ToList<int>();
        UVs = mesh.uv.ToList<Vector2>();
    }

    public void set_data(Vector3[] _verticies,int[] _triangles,Vector2[] _UVs)
    {
        Verticies = _verticies.ToList<Vector3>();
        Triangles = _triangles.ToList<int>();
        UVs = _UVs.ToList<Vector2>();
    }

    public void to_mesh(ref Mesh mesh)
    {
        mesh.vertices = Verticies.ToArray();
        mesh.triangles = Triangles.ToArray();
        mesh.uv = UVs.ToArray();
        //mesh.UploadMeshData(false);
    }

    public MeshData clone()
    {
        MeshData MD = new MeshData();
        MD.Verticies = this.Verticies.ToArray().ToList<Vector3>();
        MD.Triangles = this.Triangles.ToArray().ToList<int>();
        MD.target_TRANS = this.target_TRANS;
        MD.UVs = this.UVs.ToArray().ToList<Vector2>();
        return MD;
    }

    public string VarToString()
    {
        string result = "";

        foreach (Vector3 vert in Verticies)
        {
            result += " " + vert.ToString("F2");
        }
        result += " \n";
        foreach (int tria in Triangles)
        {
            result += " " + tria.ToString();
        }
        result += " \n";
        foreach (Vector2 uv in UVs)
        {
            result += " " + uv.ToString("F2");
        }

        return result;
    }

}
