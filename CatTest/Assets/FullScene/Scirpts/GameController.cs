using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //State strings, same as the name in animator controller;
    public const string State_TTNPC = "ToTalkToNPC";
    public const string State_TCC = "ToCatchCat";
    public const string State_TRC = "ToReturnCat";
    public const string State_Finished = "Finished";

    //Text string showing in canvas;
    public const string State_Text1 = "Talk to the NPC";
    public const string State_Text2 = "Try to catch cat";
    public const string State_Text3 = "You caught the cat! Return to NPC";
    public const string State_Text4 = "Good job!!!!!";

    public Text StateIndicatorText;

    public Animator GCAnimator { get; set; }

    // Use this for initialization
    void Start () {
        this.GCAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //Update canvas text;
        if (GCAnimator.GetCurrentAnimatorStateInfo(0)
                                .IsName(GameController.State_TTNPC))
        {
            StateIndicatorText.text = State_Text1;
        }
        else if (GCAnimator.GetCurrentAnimatorStateInfo(0)
                                        .IsName(GameController.State_TCC))
        {
            StateIndicatorText.text = State_Text2;
        }
        else if (GCAnimator.GetCurrentAnimatorStateInfo(0)
                                        .IsName(GameController.State_TRC))
        {
            StateIndicatorText.text = State_Text3;
        }
        else if (GCAnimator.GetCurrentAnimatorStateInfo(0)
                                .IsName(GameController.State_Finished))
        {
            StateIndicatorText.text = State_Text4;
        }
    }
}
