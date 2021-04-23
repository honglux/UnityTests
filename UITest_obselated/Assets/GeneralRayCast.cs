using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralRayCast : MonoBehaviour
{
    [HideInInspector]
    public RaycastHit RayHit;

    [SerializeField] private Transform FromPosition;
    [SerializeField] private LayerMask HitMask;
    [SerializeField] private LineRenderer line;

    private void Awake()
    {
        this.RayHit = new RaycastHit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] positions = new Vector3[] { FromPosition.position, RayHit.point };
        line.SetPositions(positions);
    }

    private void FixedUpdate()
    {
        ray_cast();
    }

    private void ray_cast()
    {
        Ray ray = new Ray(FromPosition.position, FromPosition.forward);

        Physics.Raycast(ray, out RayHit, 100.0f, HitMask);

        //Debug.Log("Ray Hit " + RayHit.transform.name);
    }
}
