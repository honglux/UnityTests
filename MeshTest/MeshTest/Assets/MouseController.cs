using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private static Ray ray;

    [SerializeField] private MyRayCast MRC_script;
    [SerializeField] private LineRenderer LR;

    public Vector3 start_point { get; set; }
    public Vector3 end_point { get; set; }

    private void Awake()
    {
        this.start_point = new Vector3();
        this.end_point = new Vector3();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mouse_down();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            mouse_up();
        }
    }

    private void FixedUpdate()
    {
        MRC_script.ray_cast(ray);
    }

    private void mouse_down()
    {
        if(MRC_script.HitPos != RC.NANVector3)
        {
            start_point = MRC_script.HitPos;
        }
    }

    private void mouse_up()
    {
        if (MRC_script.HitPos != RC.NANVector3)
        {
            end_point = MRC_script.HitPos;
        }

        LR.SetPositions(new Vector3[] { start_point, end_point });

        MeshCutter.IS.get_lines_Acut(start_point, end_point);
    }
}
