using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDgridtest : MonoBehaviour
{
    public Camera camera;
    public GameObject spawn_prefab;

    // Start is called before the first frame update
    void Start()
    {
        cal_spawn(0.3f, 0.3f);
        cal_spawn(0.6f, 0.3f);
        cal_spawn(0.9f, 0.3f);
        cal_spawn(0.3f, 0.6f);
        cal_spawn(0.6f, 0.6f);
        cal_spawn(0.9f, 0.6f);
        cal_spawn(0.3f, 0.9f);
        cal_spawn(0.6f, 0.9f);
        cal_spawn(0.9f, 0.9f);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void cal_spawn(float xp, float yp)
    {
        Vector3 pos = camera.ViewportToWorldPoint(new Vector3(xp, yp, 10.0f));
        Instantiate(spawn_prefab, pos, Quaternion.identity);
    }
}
