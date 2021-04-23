using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Simulator : MonoBehaviour {

    [SerializeField] LayerMask RayLayerMask;
    [SerializeField] Camera camera2;

    public RaycastHit hit { get; set; }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.Rotate(
            new Vector3(-(Input.GetAxis("Vertical")), Input.GetAxis("Horizontal"), 0.0f));
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawLine(ray.origin, (ray.origin + ray.direction * 100.0f), Color.blue);

        //PointerEventData pointerData = new PointerEventData(EventSystem.current);

        ////pointerData.position = transform.position;
        //pointerData.position = new Vector3(0.0f,0.0f,0.0f);

        ////Debug.Log("mouse " + Input.mousePosition);

        //List<RaycastResult> results = new List<RaycastResult>();
        //EventSystem.current.RaycastAll(pointerData, results);
        ////Debug.Log("results " + results.Count);
        //if (results.Count > 0)
        //{
        //    string dbg = "Root Element: {0} \n GrandChild Element: {1}";
        //    //Debug.Log(string.Format(dbg, results[results.Count - 1].gameObject.name, results[0].gameObject.name));
        //    //Debug.Log("Root Element: "+results[results.Count-1].gameObject.name);
        //    //Debug.Log("GrandChild Element: "+results[0].gameObject.name);
        //    PointerEventData pointer = new PointerEventData(EventSystem.current);
        //    ExecuteEvents.Execute(results[results.Count - 1].gameObject, pointer, 
        //                                            ExecuteEvents.pointerEnterHandler);
        //    if(Input.GetKeyDown(KeyCode.A))
        //    {
        //        ExecuteEvents.Execute(results[results.Count - 1].gameObject, pointer,
        //                                                ExecuteEvents.pointerClickHandler);
        //    }
        //    if(Input.GetKeyUp(KeyCode.A))
        //    {
        //        ExecuteEvents.Execute(results[results.Count - 1].gameObject, pointer,
        //                                                ExecuteEvents.pointerUpHandler);
        //    }

        //}

        //RaycastHit[] hits = Physics.RaycastAll(ray, 100.0f, RayLayerMask);

        RaycastHit temphit;

        Physics.Raycast(ray, out temphit, 100.0f, RayLayerMask);

        hit = temphit;

        ////Debug.Log("hits " + hits.Length);

        ////foreach(RaycastHit hit in hits)
        ////{
        ////    Debug.Log("hit " + hit.transform.name);
        ////}

        //Ray ray2 = camera2.ScreenPointToRay(new Vector3(0.0f, 0.0f, 0.0f));
        //Debug.DrawRay(ray.origin, ray.direction * 50000000, Color.red);


        //results.Clear();
    }
}
