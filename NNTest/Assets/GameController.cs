using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform Ball_TRANS;
    [SerializeField] bool UsingRandom;
    [SerializeField] float RandomTime;

    private float timer1;

    private void Awake()
    {
        this.timer1 = 0.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(UsingRandom)
        {
            timer1 += Time.deltaTime;
            if(timer1 > RandomTime)
            {
                timer1 = 0.0f;
                action1();
            }
        }
    }

    private void action1()
    {
        Vector3 random_pos = 
            new Vector3(0.0f, Random.Range(-4.0f, 4.0f), Ball_TRANS.position.z);
        Ball_TRANS.position = random_pos;
    }
}
