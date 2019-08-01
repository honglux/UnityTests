using UnityEngine;

public class MeshLine
{

    public float k { get; set; }
    public float b { get; set; }
    public bool vert_line { get; set; }
    public float vert_x { get; set; }
    public Vector3 start_point { get; set; }
    public Vector3 end_point { get; set; }
    public bool infinite { get; set; }

    public MeshLine()
    {
        this.k = 0.0f;
        this.b = 0.0f;
        this.vert_line = false;
        this.vert_x = 0.0f;
        this.start_point = new Vector3();
        this.end_point = new Vector3();
        this.infinite = false;
    }

    /// <summary>
    /// Point beyond the line;
    /// If line is vertical, then judge to the left of the line.
    /// </summary>
    /// <param name="MP"></param>
    /// <returns></returns>
    public int position_cal(MeshPoint MP)
    {
        if(vert_line)
        {
            if(MP.pos.x < vert_x)
            {
                return 1;
            }
            else if(MP.pos.x == vert_x)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        float Nkx = -k * MP.pos.x;
        float result = Nkx + MP.pos.y - b;
        if(result > 0)
        {
            return 1;
        }
        else if(result == 0)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }

    public void line_cal(MeshPoint p1, MeshPoint p2)
    {
        start_point = p1.pos;
        end_point = p2.pos;
        if ((p2.pos.x - p1.pos.x) == 0.0f)
        {
            vert_line = true;
            vert_x = p2.pos.x;
            k = float.MinValue;
            return;
        }

        k = (p2.pos.y - p1.pos.y) / (p2.pos.x - p1.pos.x);
        b = p1.pos.y - p1.pos.x * k;
    }

    public Vector3 point_calx(float x)
    {
        float y = x * k + b;
        return new Vector3(x, y, 0.0f);
    }

    public Vector3 point_caly(float y)
    {
        float x = (y - b) / k;
        return new Vector3(x, y, 0.0f);
    }

    private bool point_in_cal(Vector3 point)
    {
        if(infinite)
        {
            return false;
        }
        bool xresult = false;
        bool yresult = false;
        if (start_point.x <= end_point.x)
        {
            xresult = (point.x >= start_point.x) && (point.x <= end_point.x);
        }
        else
        {
            xresult = (point.x <= start_point.x) && (point.x >= end_point.x);
        }
        if(start_point.y <= end_point.y)
        {
            yresult = (point.y >= start_point.y) && (point.y <= end_point.y);
        }
        else
        {
            yresult = (point.y <= start_point.y) && (point.y >= end_point.y);
        }

        return xresult && yresult;
    }

    public string VarToString()
    {
        string result = "";

        result += " k " + k.ToString("F2");
        result += " b " + b.ToString("F2");
        result += " vert_line " + vert_line.ToString();
        result += " vert_x " + vert_x.ToString("F2");
        result += " start_point " + start_point.ToString("F2");
        result += " end_point " + end_point.ToString("F2");
        result += " infinite " + infinite.ToString();
        result += "\n";

        return result;
    }

    public static Vector3 line_inter_cal(MeshLine ML1, MeshLine ML2)
    {
        Vector3 pos = new Vector3();
        if((ML1.vert_line && ML2.vert_line) || (ML1.k == ML2.k))
        {
            return RC.NANVector3;
        }
        if(ML1.vert_line)
        {
            pos = ML2.point_calx(ML1.vert_x);
        }
        else if(ML2.vert_line)
        {
            pos = ML1.point_calx(ML2.vert_x);
        }
        else
        {
            float x = -(ML2.b - ML1.b) / (ML2.k - ML1.k);
            pos = ML1.point_calx(x);
        }

        if ((ML1.infinite && !ML2.infinite) && (ML2.point_in_cal(pos)))
        {
            return pos;
        }
        else if ((!ML1.infinite && ML2.infinite) && (ML1.point_in_cal(pos)))
        {
            return pos;
        }

        return RC.NANVector3;
        
    }



}
