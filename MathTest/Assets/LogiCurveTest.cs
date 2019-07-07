using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Accord.Math;
using Accord.Math.Optimization;
using Accord.Math.Optimization.Losses;
using Accord.Statistics.Kernels;
using System;

public class LogiCurveTest : MonoBehaviour
{
    [SerializeField] private PlotController PC_script;

    double[][] inputs =
    {
        new[] { 3.0, 1.0 },
        new[] { 7.0, 1.0 },
        new[] { 3.0, 1.0 },
        new[] { 3.0, 2.0 },
        new[] { 6.0, 1.0 },
    };

    // The task is to output a non-linear combination 
    // of those numbers: log(7.4x) / sqrt(1.1y + 42)
    double[] outputs =
    {
        Math.Log(7.4*3.0) / Math.Sqrt(1.1*1.0 + 42.0),
        Math.Log(7.4*7.0) / Math.Sqrt(1.1*1.0 + 42.0),
        Math.Log(7.4*3.0) / Math.Sqrt(1.1*1.0 + 42.0),
        Math.Log(7.4*3.0) / Math.Sqrt(1.1*2.0 + 42.0),
        Math.Log(7.4*6.0) / Math.Sqrt(1.1*1.0 + 42.0),
    };

    private Func<double[], double[], double> model;
    Func<double[], double> objective;
    Cobyla cobyla;

    // Start is called before the first frame update
    void Start()
    {
        init_func();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            double[] results = learning();
            double[] dx = new double[] { 1, 2, 3, 4, 5 };
            PC_script.init_val(dx, outputs, dx, results);
            PC_script.plot();
        }
    }

    private void init_func()
    {
        model = (double[] x, double[] w) => Math.Log(w[0] * x[0]) / Math.Sqrt(w[1] * x[1] + w[2]);

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

        cobyla = new Cobyla(numberOfVariables: 3) // we have 3 parameters: w0, w1, and w2
        {
            Function = objective,
            MaxIterations = 100,
            Solution = new double[] { 1.0, 6.4, 100 } // start with some random values
        };
    }

    private double[] learning()
    {
        //////
        bool success = cobyla.Minimize(); // should be true

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
