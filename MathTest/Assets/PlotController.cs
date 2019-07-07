using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotController : MonoBehaviour
{
    [SerializeField] private Transform Dots_TRANS;
    [SerializeField] private Transform Lines_TRANS;
    [SerializeField] private GameObject Dots_Prefab;

    [SerializeField] private float x_size;
    [SerializeField] private float y_size;
    [SerializeField] private float z_dist;

    private double[] Dots_x;
    private double[] Dots_y;
    private double[] Lines_x;
    private double[] Lines_y;
    private double dx_max;
    private double dx_min;
    private double dy_max;
    private double dy_min;
    private double dx_k;
    private double dy_k;
    private bool orig_flag;

    // Start is called before the first frame update
    void Start()
    {
        this.dx_max = 0;
        this.dx_min = 0;
        this.dy_max = 0;
        this.dy_min = 0;
        this.dx_k = 0;
        this.dy_k = 0;
        this.orig_flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void init_val(double[] dx, double[] dy, double[] lx, double[] ly)
    {
        Dots_x = dx;
        Dots_y = dy;
        Lines_x = lx;
        Lines_y = ly;
        init_cal();
    }
    
    private void init_cal()
    {
        double max = double.MinValue;
        double min = double.MaxValue;
        foreach(double dxv in Dots_x)
        {
            if(dxv > max)
            {
                max = dxv;
            }
            if (dxv < min)
            {
                min = dxv;
            }
        }
        dx_max = max;
        dx_min = min;
        dx_k = x_size / (dx_max - dx_min);

        max = double.MinValue;
        min = double.MaxValue;
        foreach (double dyv in Dots_y)
        {
            if (dyv > max)
            {
                max = dyv;
            }
            if (dyv < min)
            {
                min = dyv;
            }
        }
        dy_max = max;
        dy_min = min;
        dy_k = y_size / (dy_max - dy_min);

        Debug.Log("Dots_x " + Dots_x.Length);
        Debug.Log("Dots_y " + Dots_y.Length);
        Debug.Log("Lines_x " + Lines_x.Length);
        Debug.Log("Lines_y " + Lines_y.Length);
    }

    public void plot()
    {
        Vector3[] dotsx_pos = new Vector3[Dots_x.Length]; 
        Vector3[] linesx_pos = new Vector3[Dots_x.Length];

        int inter = 0;
        foreach (double dx in Dots_x)
        {
            double x = scal_cal(dx, dx_min, dx_k);
            dotsx_pos[inter].x = (float)x;
            inter++;
        }

        inter = 0;
        foreach (double dy in Dots_y)
        {
            double y = scal_cal(dy, dy_min, dy_k);
            dotsx_pos[inter].y = (float)y;
            dotsx_pos[inter].z = z_dist;
            inter++;
        }

        inter = 0;
        foreach (double lx in Lines_x)
        {
            double x = scal_cal(lx, dx_min, dx_k);
            linesx_pos[inter].x = (float)x;
            inter++;
        }

        inter = 0;
        foreach (double ly in Lines_y)
        {
            double y = scal_cal(ly, dy_min, dy_k);
            linesx_pos[inter].y = (float)y;
            linesx_pos[inter].z = z_dist;
            inter++;
        }

        if(!orig_flag)
        {
            foreach (Vector3 dp in dotsx_pos)
            {
                Instantiate(Dots_Prefab, dp, Quaternion.identity);
            }
            orig_flag = true;
        }

        Lines_TRANS.GetComponent<LineRenderer>().positionCount = linesx_pos.Length;
        Lines_TRANS.GetComponent<LineRenderer>().SetPositions(linesx_pos);
    }

    private double scal_cal(double val,double min,double k)
    {
        return (val - min) * k;
    }
}
