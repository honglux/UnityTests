

public class MeshLine
{

    public float k { get; set; }
    public float b { get; set; }
    public bool vert_line { get; set; }
    public float vert_x { get; set; }

    public MeshLine()
    {
        this.k = 0.0f;
        this.b = 0.0f;
        this.vert_line = false;
        this.vert_x = 0.0f;
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
        if((p2.pos.x - p1.pos.x) == 0.0f)
        {
            vert_line = true;
            vert_x = p2.pos.x;
            return;
        }

        k = (p2.pos.y - p1.pos.y) / (p2.pos.x - p1.pos.x);
        b = p1.pos.y - p1.pos.x * k; 
    }

    public string VarToString()
    {
        string result = "";

        result += " k " + k.ToString("F2");
        result += " b " + b.ToString("F2");
        result += " vert_line " + vert_line.ToString();
        result += " vert_x " + vert_x.ToString("F2");
        result += "\n";

        return result;
    }

}
