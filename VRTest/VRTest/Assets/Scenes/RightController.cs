using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightController : MonoBehaviour {

    [SerializeField] private LayerMask RCRayMask;

    [SerializeField] private float MaxDistance = 100.0f;

    public Vector3 hit_point { get; set; }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.localPosition = 
                        OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        transform.localRotation = 
                        OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);

    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, MaxDistance, RCRayMask);
        if(hit.transform.gameObject.layer == LayerMask.NameToLayer("WorldUI"))
        {
            hit_point = hit.point;
        }
        //Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.blue);

        Vector3[] positions = { transform.position, hit.point };
        GetComponent<LineRenderer>().SetPositions(positions);

        transform.parent.Find("HitIndicator").position = hit.point;
    }
}
