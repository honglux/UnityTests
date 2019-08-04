using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SharpLearning.Neural;
using SharpLearning.Neural.Layers;
using SharpLearning.Neural.Learners;
using SharpLearning.Neural.Loss;
using SharpLearning.Containers.Matrices;
using SharpLearning.Neural.Models;
using SharpLearning.Metrics.Regression;


public class AgentController2 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D RD;
    [SerializeField] private HumanController HC_script;
    [SerializeField] private TextMesh TM;
    [SerializeField] private TextMesh TM2;

    NeuralNet net;
    RegressionNeuralNetLearner learner;

    private bool agent_play;

    private void Awake()
    {
        this.agent_play = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        net = new NeuralNet();
        net.Add(new InputLayer(2));
        net.Add(new DenseLayer(8));
        net.Add(new DenseLayer(8));
        net.Add(new SquaredErrorRegressionLayer());

        learner = new RegressionNeuralNetLearner(net,new SquareLoss(), iterations: 1, batchSize: 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        double[] input = get_input();
        double[] output = get_output();

        F64Matrix input_M = new F64Matrix(input, 1, 2);

        RegressionNeuralNetModel model;
        if (!agent_play)
        {
            model = learner.Learn(input_M, output);
        }
        else
        {
            model = new RegressionNeuralNetModel(net);
        }
        

        double[] predictions = model.Predict(input_M);

        if(agent_play)
        {
            agent_work(predictions);
        }

        MeanSquaredErrorRegressionMetric metric = new MeanSquaredErrorRegressionMetric();
        var error = metric.Error(output, predictions);

        TM.text = error.ToString("F2");
        TM2.text = predictions[0].ToString("F2");
    }

    private double[] get_input()
    {
        double[] input = new double[2];
        input[0] = RD.position.y;
        input[1] = RD.velocity.y;
        return input;
    }

    private double[] get_output()
    {
        double[] output = new double[1];
        if (HC_script.force_flag)
        {
            output[0] = 10.0f;
        }
        else
        {
            output[0] = 0.0f;
        }

        return output;
    }

    private void agent_work(double[] predi)
    {
        if(predi[0] > 5.0f)
        {
            HC_script.force_flag = true;
        }
        else
        {
            HC_script.force_flag = false;
        }
    }
}
