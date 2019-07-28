using UnityEngine;
using System.Collections.Generic;

public class MeshPoint
{
    public Vector2 pos { get; set; }
    public bool is_cut_point { get; set; }
    public Vector2 uv { get; set; }
    public float z_pos { get; set; }


    public MeshPoint()
    {
        this.pos = new Vector2();
        this.is_cut_point = false;
        this.uv = new Vector2();
        this.z_pos = 0.0f;
    }

    public MeshPoint(MeshPoint MP)
    {
        this.pos = MP.pos;
        this.is_cut_point = MP.is_cut_point;
        this.uv = MP.uv;
        this.z_pos = MP.z_pos;
    }

    public MeshPoint(Vector3 _pos, bool _ICP)
    {
        this.pos = new Vector2(_pos.x,_pos.y);
        this.is_cut_point = _ICP;
        this.uv = new Vector2();
        this.z_pos = _pos.z;
    }

    public MeshPoint clone()
    {
        MeshPoint MP = new MeshPoint(this);
        return MP;
    }

    public Vector3 to_v3()
    {
        return new Vector3(pos.x, pos.y, z_pos);
    }

    public string VarToString()
    {
        string result = "";
        result += " pos " + pos.ToString("F2");
        result += " is_cut_point " + is_cut_point.ToString();
        result += " uv " + uv.ToString("F2");
        result += " z_pos " + z_pos.ToString("F2");
        result += "\n";

        return result;
    }


    #region:static

    public static List<MeshPoint> FromVec2(List<Vector2> list_v2)
    {
        List<MeshPoint> list_MP = new List<MeshPoint>();
        MeshPoint MP;
        foreach (Vector2 v2 in list_v2)
        {
            MP = new MeshPoint();
            MP.pos = v2;
            list_MP.Add(MP);
        }

        return list_MP;
    }

    public static List<MeshPoint> FromVec3(List<Vector3> list_v3)
    {
        List<MeshPoint> list_MP = new List<MeshPoint>();
        MeshPoint MP;
        foreach (Vector3 v3 in list_v3)
        {
            MP = new MeshPoint();
            MP.pos = new Vector2(v3.x,v3.y);
            MP.z_pos = v3.z;
            list_MP.Add(MP);
        }
        return list_MP;
    }

    public static List<MeshPoint> FromVec3(List<Vector3> list_v3,List<Vector2> UVs)
    {
        List<MeshPoint> list_MP = new List<MeshPoint>();
        MeshPoint MP;
        int iter = 0;
        foreach (Vector3 v3 in list_v3)
        {
            MP = new MeshPoint();
            MP.pos = new Vector2(v3.x, v3.y);
            MP.z_pos = v3.z;
            MP.uv = UVs[iter];
            list_MP.Add(MP);
            iter++;
        }
        return list_MP;
    }

    public static void SepLists(List<MeshPoint> list_MP,
                                out List<Vector3> list_v3,out List<Vector2> list_uv)
    {
        list_v3 = new List<Vector3>();
        list_uv = new List<Vector2>();
        foreach (MeshPoint MP in list_MP)
        {
            list_v3.Add(new Vector3(MP.pos.x, MP.pos.y, MP.z_pos));
            list_uv.Add(MP.uv);
        }
    }

    #endregion
}
