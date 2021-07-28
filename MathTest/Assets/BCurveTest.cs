using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCurveTest : MonoBehaviour
{
    [SerializeField] private LineRenderer lR;
    [SerializeField] private int nodeNumber;
    [SerializeField] private Transform P0;
    [SerializeField] private Transform P1;
    [SerializeField] private Transform P2;
    [SerializeField] private Transform P3;
    [SerializeField] private Transform S0;
    [SerializeField] private Transform S1;
    [SerializeField] private Transform S2;
    [SerializeField] private Transform S3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BCTest_update();
    }

    private void BCTest_update()
    {
        Vector3 p0p = P0.position;
        //Vector3 p1p = P1.position;
        //Vector3 p2p = P2.position;
        Vector3 p3p = P3.position;

        Vector3 p1p = p0p + Vector3.Scale((p3p - p0p), (new Vector3(-0.3f, 0.8f, 1.0f)));
        Vector3 p2p = p0p + Vector3.Scale((p3p - p0p), (new Vector3(0.1f, 1.4f, 1.0f)));

        float gap = 1.0f / (float)nodeNumber;

        Vector3[] respos = new Vector3[nodeNumber];
        float progress = 0.0f;
        for(int i = 0; i<nodeNumber; ++i)
        {
            progress = i * gap;
            respos[i] = Mathf.Pow((1 - progress), 3) * p0p + 3.0f * Mathf.Pow((1 - progress), 2) * progress * p1p +
                3.0f * (1 - progress) * Mathf.Pow(progress, 2) * p2p + Mathf.Pow(progress, 3) * p3p;
        }

        S0.position = respos[0];
        S1.position = respos[1];
        S2.position = respos[2];
        S3.position = respos[3];

        //S0.up = S1.position - S0.position;
        //S1.up = S2.position - S1.position;
        //S2.up = S3.position - S2.position;
        //S3.up = p3p - S3.position;

        LA(S1.position, S0.position, S0);
        LA(S2.position, S1.position, S1);
        LA(S3.position, S2.position, S2);
        LA(p3p, S3.position, S3);

        lR.positionCount = nodeNumber;
        lR.SetPositions(respos);
    }

    public void LA(Vector3 p1, Vector3 p2, Transform t1)
    {
        Vector3 dir = (p2 - p1).normalized;

        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        t1.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
