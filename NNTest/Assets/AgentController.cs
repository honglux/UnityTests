using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using AForge.Neuro.Learning;
//using AForge.Neuro;
using Accord.Neuro;
using Accord.Neuro.Learning;

public class AgentController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D RD;
    [SerializeField] private HumanController HC_script;
    [SerializeField] private TextMesh TM;
    [SerializeField] private TextMesh TM2;

    private ActivationNetwork network;
    private ActivationNetwork network2;
    private ActivationNetwork network3;
    private ActivationNetwork network4;
    private BackPropagationLearning teacher;
    private BackPropagationLearning teacher2;
    private BackPropagationLearning teacher3;
    private BackPropagationLearning teacher4;
    private bool agent_play;

    private void Awake()
    {
        this.agent_play = false;
        //ActivationLayer activationLayer1 = new ActivationLayer(4, 2, new LinearFunction());
        //ActivationLayer activationLayer2 = new ActivationLayer(1, 4, new LinearFunction());
        this.network = new ActivationNetwork(new LinearFunction(),
            2,
            8);
        teacher = new BackPropagationLearning(network);
        /////
        this.network2 = new ActivationNetwork(new SigmoidFunction(),
            8,
            8);
        teacher2 = new BackPropagationLearning(network2);
        /////
        this.network3 = new ActivationNetwork(new LinearFunction(),
            8,
            1);
        teacher3 = new BackPropagationLearning(network3);
        /////
        this.network4 = new ActivationNetwork(new SigmoidFunction(),
            1,
            1);
        teacher4 = new BackPropagationLearning(network4);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            agent_play = !agent_play;
        }

        double[] input = get_input();
        double[] output = get_output();

        double[][] outputs = agent_output(input);

        if (!agent_play)
        {
            double error4 = teacher4.Run(outputs[2], output);
            double error3 = teacher3.Run(outputs[1], outputs[2]);
            double error2 = teacher2.Run(outputs[0], outputs[1]);
            double error1 = teacher.Run(input, outputs[0]);
            TM.text = error4.ToString("F4");
        }
        TM2.text = outputs[3][0].ToString("F2");

        if(agent_play)
        {
            agent_work(input);
        }
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
        if(HC_script.force_flag)
        {
            output[0] = 1;
        }
        else
        {
            output[0] = 0;
        }

        return output;
    }

    private double[][] agent_output(double[] input)
    {
        double[][] outputs = new double[4][];
        outputs[0] = network.Compute(input);
        outputs[1] = network2.Compute(outputs[0]);
        outputs[2] = network3.Compute(outputs[1]);
        outputs[3] = network4.Compute(outputs[2]);

        //int index = 0;
        //foreach (double[] output in outputs)
        //{
        //    Debug.Log("output " + index.ToString() + " " + output.Length);
        //    index++;
        //}

        return outputs;
    }

    private void agent_work(double[] input)
    {
        double[][] outputs = agent_output(input);
        {
            if(outputs[3][0] > 0.5f)
            {
                HC_script.force_flag = true;
            }
            else
            {
                HC_script.force_flag = false;
            }
        }
    }
}
