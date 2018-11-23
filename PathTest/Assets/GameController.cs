using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] private float RandomX;
    [SerializeField] private float RandomY;
    [SerializeField] private float InitZ;
    [SerializeField] private float GenerateTime;
    [SerializeField] private GameObject position_Prefab;
    [SerializeField] private PositionQueue PQ_script;
    [SerializeField] private MouseRayCast MRC_script;

    private float generate_timer;
    private bool generate_timer_flag;

    // Use this for initialization
    void Start () {
        this.generate_timer = GenerateTime;
        this.generate_timer_flag = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(generate_timer_flag)
        {
            generate_timer -= Time.deltaTime;
        }

        if(generate_timer < 0.0f)
        {
            generate_position();
            generate_timer = GenerateTime;
        }
	}

    private Vector3 random_generator()
    {
        return new Vector3(Random.Range(-RandomX, RandomX),
                            Random.Range(-RandomY, RandomY),
                            InitZ);
    }

    private void generate_position()
    {
        //GameObject position_OBJ =
        //            Instantiate(position_Prefab, random_generator(), new Quaternion());
        if(MRC_script.Holding_mouse && MRC_script.Mouse_pos != new Vector3())
        {
            GameObject position_OBJ =
                Instantiate(position_Prefab, MRC_script.Mouse_pos, new Quaternion());
            PQ_script.PosQueue.Enqueue(position_OBJ.transform);
        }

    }
}
