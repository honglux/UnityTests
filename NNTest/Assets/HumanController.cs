using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D RD;
    [SerializeField] private float Force;

    public bool force_flag { get; set; }

    private void Awake()
    {
        this.force_flag = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            force_flag = true;
        }
        else
        {
            force_flag = false;
        }
    }

    private void FixedUpdate()
    {
        if(force_flag)
        {
            RD.AddForce(Vector3.up * Force);
        }
    }
}
