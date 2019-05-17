using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinearRegression : MonoBehaviour
{
    public TextMesh text;

    public float[] x_array;
    public float[] y_array;
    public float x;
    public float y;

    private List<float> x_list;
    private List<float> y_list;

    private float b0;
    private float b1;

    // Start is called before the first frame update
    void Start()
    {
        this.x_list = new List<float>(x_array);
        this.y_list = new List<float>(y_array);
        this.b0 = 0.0f;
        this.b1 = 0.0f;
        this.x = 0.0f;
        this.y = 0.0f;

        //Debug.Log("pow test " + Mathf.Pow(3, 2));

        linear_regression();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (b0 + x * b1).ToString("F2");
    }

    private void linear_regression()
    {
        float x_mean = x_list.Average();
        float y_mean = y_list.Average();
        float x_variance = 0.0f;
        float x_Vsum = 0.0f;
        foreach(float x in x_list)
        {
            x_variance = Mathf.Pow(x - x_mean, 2);
            x_Vsum += x_variance;
        }
        float x_standardD = 0.0f;
        float y_standardD = 0.0f;
        float xSD_ySD = 0.0f;
        float xSD_ySD_sum = 0.0f;
        for(int i = 0; i<x_list.Count;i++)
        {
            x_standardD = x_list[i] - x_mean;
            y_standardD = y_list[i] - y_mean;
            xSD_ySD = x_standardD * y_standardD;
            xSD_ySD_sum += xSD_ySD;
        }
        b1 = xSD_ySD_sum / x_Vsum;
        Debug.Log("b1 " + b1);
        Debug.Log("x_Vsum " + x_Vsum);
        Debug.Log("xSD_ySD_sum " + xSD_ySD_sum);
        b0 = y_mean - b1 * x_mean;
    }
}
