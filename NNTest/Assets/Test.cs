using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AForge.Neuro.Learning;
using AForge.Neuro;

public class Test : MonoBehaviour
{
    ActivationNetwork network;
    BackPropagationLearning teacher;

    [SerializeField] private Transform TestText_TRANS;
    [SerializeField] private Transform OutText_TRANS;

    // Start is called before the first frame update
    void Start()
    {

        // create neural network
        this.network = new ActivationNetwork(
            new SigmoidFunction(),
            1, // two inputs in the network
            2,
            1); // one neuron in the second layer
                // create teacher
        teacher = new BackPropagationLearning(network);
        // loop
        // run epoch of learning procedure
        // check error value to see if we need to stop
        // .
    }

    // Update is called once per frame
    void Update()
    {
        //double[] input = { Random.Range(-100.0f, 100.0f) };
        //double[] output = { (input[0]+100.0f) * 2.0f / 400.0f };
        
        double[] input = { Random.Range(-10.0f, 10.0f) };
        //double[] output = input;
        double[] output = { (input[0] + 10.0f) / 20.0f };
        Debug.Log("output " + 
            ((output[0] > 1.0d || output[0] < -1.0d) ? output[0].ToString() : ""));
        //double[] input = { 0.0d };
        //double[] output = { 1.0d };
        double error = teacher.Run(input, output);
        TestText_TRANS.GetComponent<TextMesh>().text = error.ToString("F4");
    }


}
