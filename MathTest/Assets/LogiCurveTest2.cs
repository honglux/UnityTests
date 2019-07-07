using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.IO;

using Accord.Math;
using Accord.Math.Optimization;
using Accord.Math.Optimization.Losses;
using Accord.Statistics.Kernels;


public class LogiCurveTest2 : MonoBehaviour
{
    private static char[] file_spliter = new char[] { ' ', '\t' };

    [SerializeField] private PlotController PC_script;
    [SerializeField] private Transform Text1_TRANS;

    [SerializeField] private string file_path;
    [SerializeField] private int length;
    [SerializeField] private int max_num;
    [SerializeField] private int section_num;

    double[] inputs;
    double[] outputs;
    private Func<double, double[], double> model;
    private Func<double[], double> objective;
    private Cobyla cobyla;
    private bool success;

    // Start is called before the first frame update
    void Start()
    {
        read_file();
        init_func();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            double[] results = learning();
            PC_script.init_val(inputs, outputs, inputs, results);
            PC_script.plot();
        }
    }

    private void read_file()
    {
        int[] section_data = null;
        List<int[]> sections = new List<int[]>();


        StreamReader reader = new StreamReader(file_path);
        while (!reader.EndOfStream)
        {
            string[] splitstr = reader.ReadLine().Split(file_spliter);
            //foreach(string str in splitstr)
            //{
            //    Debug.Log(str);
            //}
            if (splitstr.Length > 1)
            {
                if(splitstr[0] == "Line_#")
                {
                    continue;
                }
                if (splitstr[1] == "start")
                {
                    if (section_data == null)
                    {
                        section_data = new int[length];
                    }
                    else
                    {
                        sections.Add(section_data);
                        section_data = new int[length];
                    }
                }
                else if (int.Parse(splitstr[3]) >= 0 && splitstr[4] == "True")
                {
                    section_data[int.Parse(splitstr[3])]++;
                }
            }

        }
        sections.Add(section_data);
        //foreach(int a in sections[0])
        //{
        //    Debug.Log("a " + a);
        //}

        double[] da = sections[section_num].Select(x => (double)x).ToArray();
        inputs = new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
        outputs = scale_array(da);
    }

    private double[] scale_array(double[] target_arr)
    {
        double[] new_arr = new double[target_arr.Length];
        int iter = 0;
        foreach(double val in target_arr)
        {
            new_arr[iter] = val / max_num;
            iter++;
        }
        return new_arr;
    }

    private void init_func()
    {
        model = (double x, double[] w) => (w[0] / (1.0 + Math.Pow(Math.E, (-w[1] * (x - w[2])))) + 0.125);

        objective = (double[] w) =>
        {
            double sumOfSquares = 0.0;
            for (int i = 0; i < inputs.Length; i++)
            {
                double expected = outputs[i];
                double actual = model(inputs[i], w);
                sumOfSquares += Math.Pow(expected - actual, 2);
            }
            return sumOfSquares;
        };

        cobyla = new Cobyla(numberOfVariables: 3)
        {
            Function = objective,
            MaxIterations = 100,
            Solution = new double[] { 0.5,0.1,0.9} // start with some random values
        };
    }

    private double[] learning()
    {
        //////
        success = cobyla.Minimize(); // should be true

        Text1_TRANS.GetComponent<TextMesh>().text = success.ToString();

        Debug.Log("success " + success);
        double[] solution = cobyla.Solution;
        display_array("solution", solution);

        // Get machine's predictions for inputs
        double[] prediction = inputs.Apply(x => model(x, solution));
        display_array("prediction", prediction);
        display_array("output", outputs);

        // Compute the error in the prediction (should be 0.0)
        double error = new SquareLoss(outputs).Loss(prediction);
        display_array("error", new double[] { error});

        return prediction;
    }

    private void display_array(string str,double[] values)
    {
        Debug.Log(str);
        int counter = 0;
        foreach(double val in values)
        {
            Debug.Log(counter.ToString() + " " + val);
            counter++;
        }

    }
}
