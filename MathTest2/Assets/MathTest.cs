using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTest : MonoBehaviour
{
    [SerializeField] private TextMesh TM;
    [SerializeField] private Vector2[] verts;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        area_test1();
    }

    private float area_cal(Vector2[] verts)
    {
        float left = 0.0f, right = 0.0f;
        float sum = 0.0f;
        for(int i = 0;i<verts.Length-1;i++)
        {
            left = verts[i].x * verts[i + 1].y;
            right = verts[i+1].x * verts[i].y;
            sum += left - right;
        }
        sum += verts[verts.Length - 1].x * verts[0].y - verts[0].x * verts[verts.Length - 1].y;
        sum /= 2.0f;
        return Mathf.Abs(sum);
    }

    private void area_test1()
    {
        float ans = area_cal(verts);
        TM.text = ans.ToString("F2");
    }
}
