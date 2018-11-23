using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRayCast : MonoBehaviour {

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Camera camera;

    public Vector3 Mouse_pos { get; set; }
    public bool Holding_mouse { get; set; }

    private RaycastHit hit;

	// Use this for initialization
	void Start () {
        this.Mouse_pos = new Vector3();
        this.Holding_mouse = false;
	}

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Holding_mouse = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Holding_mouse = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (Holding_mouse)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, layerMask))
            {
                Mouse_pos = hit.point;
            }
                
        }
    }
}
