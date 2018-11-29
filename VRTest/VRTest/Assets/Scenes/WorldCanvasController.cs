using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldCanvasController : MonoBehaviour {

    [SerializeField] private Camera RayCastCamera;
    [SerializeField] private RightController RC_script;

    public GameObject hit_OBJ { get; set; }
    public PointerEventData point_data { get; set; }

    private Vector3 hit_to_screen;
    private bool entered_flag;

    // Use this for initialization
    void Start () {
        this.point_data = new PointerEventData(EventSystem.current);
        this.hit_to_screen = new Vector3();
        this.hit_OBJ = null;
        this.entered_flag = false;
    }
	
	// Update is called once per frame
	void Update () {
        try
        {
            hit_to_screen = RayCastCamera.WorldToScreenPoint(RC_script.hit_point);
        }
        catch { }
        //Debug.Log("hit_to_screen " + hit_to_screen);
        hit_to_screen.z = 0.0f;
        point_data.position = hit_to_screen;
        //point_data.position = Input.mousePosition;

        //Ray ray2 = RayCastCamera.ScreenPointToRay(point_data.position);
        //Vector3[] positions = { ray2.origin, ray2.direction*100.0f};
        //GetComponent<LineRenderer>().SetPositions(positions);
        //Debug.DrawRay(ray2.origin, ray2.direction * 100.0f, Color.red);

        //Vector3[] positions = { transform.position, }
        //GetComponent<LineRenderer>

    }

    private void FixedUpdate()
    {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(point_data, results);

        Debug.Log("results.Count " + results.Count);
        foreach (RaycastResult rcr in results)
        {
            Debug.Log("result object " + rcr.gameObject.name);
        }

        if (results.Count > 0)
        {
            //Vector3[] positions = { transform.position,
            //                        results[results.Count - 1].worldPosition };
            //GetComponent<LineRenderer>().SetPositions(positions);
            if (!GameObject.ReferenceEquals(hit_OBJ, results[results.Count - 1].gameObject))
            {
                hit_OBJ = results[results.Count - 1].gameObject;
                ExecuteEvents.Execute(hit_OBJ, point_data, ExecuteEvents.pointerEnterHandler);
                entered_flag = true;
            }
        }
        else
        {
            if(entered_flag)
            {
                ExecuteEvents.Execute(hit_OBJ, point_data, ExecuteEvents.pointerExitHandler);
                entered_flag = false;
                hit_OBJ = null;
            }
        }

        results.Clear();
    }
}
