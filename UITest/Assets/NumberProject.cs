using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberProject : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    private bool start_flag;

    private void Awake()
    {
        start_flag = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(start_flag)
        {
            transform.Translate(transform.forward * Time.deltaTime * speed);
        }
    }

    public void start_move()
    {
        start_flag = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DefuseWall")
        {
            Destroy(gameObject);
        }
    }
}
