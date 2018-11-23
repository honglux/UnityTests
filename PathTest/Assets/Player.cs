using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private PositionQueue PQ_script;

    [SerializeField] private float MaxSpeed = 30.0f;
    [SerializeField] private float PushForce = 20.0f;
    [SerializeField] private float MinDistance = 0.1f;
    [SerializeField] private float FrictionForce = 10.0f;

    private bool get_next;
    private Vector3 next_pos;
    private Rigidbody player_RB;
    private GameObject next_pos_OBJ;

	// Use this for initialization
	void Start () {
        this.get_next = false;
        this.next_pos = new Vector3(0.0f, 0.0f, 9.0f);
        this.player_RB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("speed " + player_RB.velocity.magnitude);

        check_pos();
	}

    private void FixedUpdate()
    {
        toward_next_pos();
        apply_frition();
    }

    private void toward_next_pos()
    {
        if(!get_next)
        {
            if(PQ_script.PosQueue.Count != 0)
            {
                next_pos = get_next_pos();
                get_next = true;
            }
        }
        else
        {
            push_to_pos(next_pos);
        }
    }

    private Vector3 get_next_pos()
    {
        next_pos_OBJ = PQ_script.PosQueue.Dequeue().gameObject;
        return next_pos_OBJ.transform.position;
    }

    private void push_to_pos(Vector3 pos)
    {
        Vector3 directrion = (pos - transform.position).normalized;
        player_RB.AddForce(directrion * Time.deltaTime * PushForce);
        //player_RB.MovePosition(pos);
    }

    private void check_pos()
    {
        //Debug.Log("Distance " + Vector3.Distance(transform.position, next_pos));
        if(Vector3.Distance(transform.position,next_pos) < MinDistance)
        {
            Destroy(next_pos_OBJ);
            get_next = false;
        }
    }

    private void apply_frition()
    {
        player_RB.AddForce((-player_RB.velocity).normalized * FrictionForce * Time.deltaTime);
    }

}
