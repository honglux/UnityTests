using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour {

    [SerializeField] WorldCanvasController WCC_script;
    [SerializeField] GameObject TextIndicator1;

    private bool controller_trigger_flag;

	// Use this for initialization
	void Start () {
        this.controller_trigger_flag = false;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger") > 0.5f &&
                                                            !controller_trigger_flag)
        {
            if(WCC_script.hit_OBJ != null)
            {
                ExecuteEvents.Execute(WCC_script.hit_OBJ, WCC_script.point_data,
                                                    ExecuteEvents.pointerClickHandler);
            }
            controller_trigger_flag = true;
        }
        else if(Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger") < 0.1f)
        {
            controller_trigger_flag = false;
        }

	}

    public void button1()
    {
        TextIndicator1.GetComponent<TextMesh>().text = "button1";
    }
    public void button2()
    {
        TextIndicator1.GetComponent<TextMesh>().text = "button2";

    }
    public void button3()
    {
        TextIndicator1.GetComponent<TextMesh>().text = "button3";

    }
    public void button4()
    {
        TextIndicator1.GetComponent<TextMesh>().text = "button4";

    }
}
