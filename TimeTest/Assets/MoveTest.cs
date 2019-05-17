using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public Vector3 DestPosition;
    public float Speed;

    private Vector3 last_pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate((DestPosition - transform.position).normalized * Time.deltaTime * 
                                                                        Speed,  Space.World);
        Debug.Log("unit distance " + 
                            Vector3.Distance(last_pos, transform.position)/Time.deltaTime);
        last_pos = transform.position;

    }
}
