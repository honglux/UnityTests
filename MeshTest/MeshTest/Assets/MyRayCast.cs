using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRayCast : MonoBehaviour
{
    [SerializeField] private string ColliderTag;

    [SerializeField] private Camera mcamera;
    [SerializeField] private LayerMask RayLM;

    public Vector3 HitPos { get; private set; }
    private RaycastHit hit;

    private void Awake()
    {
        this.hit = new RaycastHit();
        this.HitPos = new Vector3();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ray_cast(Ray ray)
    {
        if (Physics.Raycast(ray, out hit, 100.0f, RayLM))
        {
            if(hit.transform.CompareTag(ColliderTag))
            {
                HitPos = hit.point;
            }
            else
            {
                HitPos = RC.NANVector3;
            }
        }
        
    }
}
