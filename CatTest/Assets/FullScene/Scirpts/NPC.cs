using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    private const string dialog1 = "Press E to Talk.";
    private const string dialog2 = "Can you help me find my cat?";
    private const string dialog3 = "That's my cat!!! That's my cat!!!";
    private const string dialog4 = "Thank you!!!";

    //public Transform Player_Trans;
    public GameController GC_script;
    public GameObject DialogText_obj;
    public InputController IC_script;

    private List<string> dialogs;
    private bool available_to_act;

    // Use this for initialization
    void Start () {
        this.dialogs = new List<string>();

        init_dialogs();

        this.available_to_act = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(available_to_act)
        {
            if(IC_script.Action_key_pressed)
            {
                choose_dialog();
            }
        }
	}

    private void init_dialogs()
    {
        dialogs.Add(dialog1);
        dialogs.Add(dialog2);
        dialogs.Add(dialog3);
        dialogs.Add(dialog4);
    }

    private void choose_dialog()
    {
        if(GC_script.GCAnimator.GetCurrentAnimatorStateInfo(0)
                                        .IsName(GameController.State_TTNPC))
        {
            display_dialog(1);
            GC_script.GCAnimator.SetTrigger("NextStep");
        }
        else if (GC_script.GCAnimator.GetCurrentAnimatorStateInfo(0)
                                        .IsName(GameController.State_TCC))
        {
            display_dialog(1);
        }
        else if (GC_script.GCAnimator.GetCurrentAnimatorStateInfo(0)
                                        .IsName(GameController.State_TRC))
        {
            display_dialog(2);
            GC_script.GCAnimator.SetTrigger("NextStep");
        }
        else if (GC_script.GCAnimator.GetCurrentAnimatorStateInfo(0)
                                .IsName(GameController.State_Finished))
        {
            display_dialog(3);
        }
    }

    private void display_dialog(int dialognumber)
    {
        DialogText_obj.GetComponent<TextMesh>().text = dialogs[dialognumber];
    }

    public void ableto_talk()
    {
        available_to_act = true;
        display_dialog(0);
        DialogText_obj.GetComponent<MeshRenderer>().enabled = true;
    }

    public void unableto_talk()
    {
        available_to_act = false;
        DialogText_obj.GetComponent<MeshRenderer>().enabled = false;
    }

}
