using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberProject : MonoBehaviour
{
    public Vector3 Target { get; set; }

    [SerializeField] private float speed = 5.0f;

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
            transform.Translate(Target.normalized * Time.deltaTime * speed,Space.World);
        }
    }

    public void start_move(Vector3 target_pos)
    {
        Target = target_pos;
        start_flag = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("RayCastOnly"))
        {
            Destroy(gameObject);
        }
    }
}
