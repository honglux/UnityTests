using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTest : MonoBehaviour
{
    [SerializeField] private GameObject dot_PREF;

    [SerializeField] private float R;
    [SerializeField] private int Inter;
    [SerializeField] private Vector2Int HStartEnd;
    [SerializeField] private Vector2Int VStartEnd;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = HStartEnd.x;i< HStartEnd.y;i += Inter)
        {
            for(int j = VStartEnd.x;j<VStartEnd.y;j += Inter)
            {
                Instantiate(dot_PREF, sphere_cal(i, j),Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 sphere_cal(float x_deg,float y_deg)
    {
        //y_deg = (90.0f - Mathf.Abs(y_deg)) * Mathf.Sign(y_deg);
        float x_raid = x_deg * Mathf.Deg2Rad;
        float y_raid = y_deg * Mathf.Deg2Rad;
        float x = R * Mathf.Sin(x_raid) * Mathf.Cos(y_raid);
        float y = R * Mathf.Sin(x_raid) * Mathf.Sin(y_raid);
        float z = R * Mathf.Cos(x_raid);
        return new Vector3(x, y, z);
    }
}
