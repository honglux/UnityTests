using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour {

    //[SerializeField] Button button;
    [SerializeField] Simulator S_script;
    [SerializeField] Camera main_camera;

    private GameObject gobject;

	// Use this for initialization
	void Start () {
        this.gobject = null;

    }
	
	// Update is called once per frame
	void Update () {

        PointerEventData pointerData = new PointerEventData(EventSystem.current);

        //Debug.Log("WTS " + main_camera.WorldToScreenPoint(S_script.hit.point));
        //Debug.Log("hit " + S_script.hit.point);

        Vector3 hit_point = new Vector3();
        try
        {
            hit_point = main_camera.WorldToScreenPoint(S_script.hit.point);
        }
        catch { }

        hit_point = new Vector3(hit_point.x, hit_point.y, 0.0f);

        //Debug.Log("hit_point " + hit_point);

        pointerData.position = hit_point;

        Ray ray2 = main_camera.ScreenPointToRay(pointerData.position);
        Debug.DrawRay(ray2.origin, ray2.direction * 50000000, Color.red);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        

        Debug.Log("results  " + results);

        if (results.Count > 0)
        {
            gobject = results[results.Count - 1].gameObject;
            ExecuteEvents.Execute(gobject, pointerData,
                                                    ExecuteEvents.pointerEnterHandler);

            if (Input.GetKeyDown(KeyCode.A)) // force hover
            {
                ExecuteEvents.Execute(gobject, pointerData, 
                                                    ExecuteEvents.pointerClickHandler);
                Debug.Log("execute?");
            }
        }
        else
        {
            ExecuteEvents.Execute(gobject, pointerData,
                                        ExecuteEvents.pointerExitHandler);
            gobject = null;
        }
        results.Clear();
    }

    public void button1()
    {
        Debug.Log("button1");
    }


}
