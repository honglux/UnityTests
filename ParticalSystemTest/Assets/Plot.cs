using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [SerializeField] private Transform PS_TRANS;

    private float x;
    private float y;

    private Vector3 init_pos;

    // Start is called before the first frame update
    void Start()
    {
        this.x = 0.0f;
        this.y = 0.0f;
        this.init_pos = PS_TRANS.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angularVelocityRead =
            (OVRPlugin.GetNodeAngularVelocity(OVRPlugin.Node.Head, OVRPlugin.Step.Render).
            FromFlippedZVector3f()) * Mathf.Rad2Deg;

        y = angularVelocityRead.y / 400.0f;

        //x++;
        //x = x > 10000 ? 0 : x;
        //y = Mathf.Sin(x / 180.0f * Mathf.PI);
        //Debug.Log("y " + y);
        PS_TRANS.localPosition = new Vector3(init_pos.x, init_pos.y + y, init_pos.z);
    }
}
