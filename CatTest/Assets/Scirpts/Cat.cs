using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {

    public GameController GC_script;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void try_picking_up()
    {
        if (GC_script.GCAnimator.GetCurrentAnimatorStateInfo(0)
                                .IsName(GameController.State_TCC))
        {
            GC_script.GCAnimator.SetTrigger("NextStep");
            Destroy(gameObject);
        }
    }
}
