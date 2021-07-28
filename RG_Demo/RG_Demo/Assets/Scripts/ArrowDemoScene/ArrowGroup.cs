using System.Collections.Generic;
using UnityEngine;
using EnumController;

public class ArrowGroup : MonoBehaviour
{
    [SerializeField] private GameObject arrow_head_Prefab;
    [SerializeField] private GameObject arrow_body_Prefab;

    ArrowSettings arr_set;
    private Transform arrow_head_TRANS;
    private Vector3[] arrow_joints;
    private List<Transform> arrow_body_TRANSs;
    private bool arrow_started;
    private Vector3 arrow_start_point;
    private Vector3 arrow_end_point;

    private void Awake()
    {
        arr_set = null;
        arrow_body_TRANSs = new List<Transform>();
        arrow_joints = null;
        arrow_head_TRANS = null;
        arrow_started = false;
        arrow_start_point = new Vector3();
        arrow_end_point = new Vector3();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateArrow();
    }

    /// <summary>
    /// Init function;
    /// </summary>
    public void InitAG(ArrowSettings _arrow_settings)
    {
        arr_set = _arrow_settings;

        if (arr_set.P12Coeff.Length < 2 || arr_set.BCurveABCD.Length < 4 || arr_set.ArrowSmoothJointNumber < 2)
        { Debug.LogError("Arrow Settings Error!"); return; }

        arrow_joints = new Vector3[arr_set.ArrowSmoothJointNumber];

        arrow_head_TRANS = Instantiate(arrow_head_Prefab,ADSRC.IS.Canvas_TRANS).transform;
        arrow_head_TRANS.position = Vector3.zero;
        arrow_head_TRANS.localScale *= arr_set.ArrowEndScale;
        arrow_head_TRANS.GetComponent<ArrowComponent>().UpdateSprite(arr_set.ArrowBodySprite);
        arrow_head_TRANS.GetComponent<ArrowComponent>().TurnOffSprite();

        Transform temp_TRANS = null;
        for (int i = 0; i < arr_set.ArrowNodeNumber; ++i) 
        {
            temp_TRANS = Instantiate(arrow_body_Prefab, ADSRC.IS.Canvas_TRANS).transform;
            temp_TRANS.position = Vector3.zero;
            temp_TRANS.localScale *= ArrowBodyScaleCal(arr_set.ArrowStartScale, arr_set.ArrowEndScale,
                i, arr_set.ArrowNodeNumber);
            temp_TRANS.GetComponent<ArrowComponent>().UpdateSprite(arr_set.ArrowBodySprite);
            temp_TRANS.GetComponent<ArrowComponent>().TurnOffSprite();
            temp_TRANS.SetSiblingIndex(i);
            arrow_body_TRANSs.Add(temp_TRANS);
        }
        arrow_head_TRANS.SetSiblingIndex(arr_set.ArrowNodeNumber);
    }

    /// <summary>
    /// Start the arrow;
    /// </summary>
    public void StartArrow(Vector3 start_pos)
    {
        arrow_started = true;
        arrow_start_point = start_pos;
        TurnOnArrow();
    }

    public void EndArrow()
    {
        ClearArrow();
    }

    /// <summary>
    /// Update the arrow position and rotation;
    /// </summary>
    private void UpdateArrow()
    {
        if (!arrow_started) { return; }
        SetArrowEndPoint(InputHandler.IS.MousePosition);
        UpdateArrowPosRot();
    }

    /// <summary>
    /// Set arrow end point.
    /// </summary>
    /// <param name="_end_position"></param>
    private void SetArrowEndPoint(Vector3 _end_position)
    {
        arrow_end_point = _end_position;
    }

    private void UpdateArrowPosRot()
    {
        switch(arr_set.CurveType)
        {
            case ArrowCurveType.CubeBCurve:
                BCurveCubeUpdateArrowPosRot();
                break;
            case ArrowCurveType.QuadBCurve:
                BCurveQuadUpdateArrowPosRot();
                break;
            default:
                BCurveCubeUpdateArrowPosRot();
                break;
        }
    }

    /// <summary>
    /// Update the positions and rotations for the arrow nodes with bezier curve function;
    /// </summary>
    private void BCurveCubeUpdateArrowPosRot()
    {
        BCurveCubePositionCal();
        SetArrowBodyPositions();
        CurveNodeRotationCal();
    }

    private void BCurveQuadUpdateArrowPosRot()
    {
        BCurveQuadPosCal();
        SetArrowBodyPositions();
        CurveNodeRotationCal();
    }

    /// <summary>
    /// Calculate the position with B curve;
    /// </summary>
    private void BCurveCubePositionCal()
    {
        Vector3 p1p = new Vector3();
        Vector3 p2p = new Vector3();
        BCurvep1p2Cal(arr_set.P12Coeff[0], arr_set.P12Coeff[1], out p1p, out p2p);
        Vector3 temp_pos = new Vector3();
        float progress = 0.0f;
        for (int i = 0; i < arrow_joints.Length; ++i) 
        {
            progress = (float)i / (float)(arrow_joints.Length);
            temp_pos = Utilities.BCubeCurveCal(arr_set.BCurveABCD[0], arr_set.BCurveABCD[1],
                    arr_set.BCurveABCD[2], arr_set.BCurveABCD[3], arrow_start_point, p1p, p2p,
                    arrow_end_point, progress);
            arrow_joints[i] = temp_pos;
        }
    }

    private void BCurveQuadPosCal()
    {
        Vector3 p1p = new Vector3();
        BCurvep1p2Cal(arr_set.P12Coeff[0], Vector3.zero, out p1p, out _);
        Vector3 temp_pos = new Vector3();
        float progress = 0.0f;
        for (int i = 0; i < arrow_joints.Length; ++i)
        {
            progress = (float)i / (float)(arrow_joints.Length);
            temp_pos = Utilities.BQuadCurveCal(arr_set.BCurveABCD[0], arr_set.BCurveABCD[1],
                arr_set.BCurveABCD[2], arrow_start_point, p1p, arrow_end_point, progress);
            arrow_joints[i] = temp_pos;
        }
    }

    private void SetArrowBodyPositions()
    {
        int joint_index = 0;
        for (int i = 0; i < arrow_body_TRANSs.Count; ++i)
        {
            joint_index = Mathf.FloorToInt((float)i / (float)(arrow_body_TRANSs.Count) * 
                (float)(arrow_joints.Length));
            arrow_body_TRANSs[i].position = arrow_joints[joint_index];
        }
        arrow_head_TRANS.position = arrow_end_point;
    }

    /// <summary>
    /// Calculate the p1 and p2 for Bezier curve'
    /// </summary>
    private void BCurvep1p2Cal(Vector3 p1coef, Vector3 p2coef, out Vector3 p1p, out Vector3 p2p)
    {
        p1p = arrow_start_point + Vector3.Scale((arrow_end_point - arrow_start_point), p1coef);
        p2p = arrow_start_point + Vector3.Scale((arrow_end_point - arrow_start_point), p2coef);
    }

    /// <summary>
    /// Calculate the rotation of the curve node;
    /// </summary>
    private void CurveNodeRotationCal()
    {
        Quaternion temp_rot = new Quaternion();
        int joint_index = 0;
        for (int i = 0; i < arrow_body_TRANSs.Count; ++i) 
        {
            joint_index = Mathf.FloorToInt((float)i / (float)(arrow_body_TRANSs.Count) *
                (float)(arrow_joints.Length));
            if(joint_index == arrow_joints.Length - 1)
            {
                temp_rot = Utilities.TowDLookAt(arrow_body_TRANSs[arrow_body_TRANSs.Count - 1].position,
                    arrow_end_point);
            }
            else
            {
                temp_rot = Utilities.TowDLookAt(arrow_body_TRANSs[i].position, arrow_joints[joint_index + 1]);
            }
            arrow_body_TRANSs[i].rotation = temp_rot;
        }
        arrow_head_TRANS.rotation = 
            Utilities.TowDLookAt(arrow_joints[arrow_joints.Length-2], arrow_joints[arrow_joints.Length - 1]);
    }

    /// <summary>
    /// Turn on arrow sprites;
    /// </summary>
    private void TurnOnArrow()
    {
        arrow_head_TRANS.GetComponent<ArrowComponent>().TurnOnSprite();
        foreach (Transform aB_TRANS in arrow_body_TRANSs)
        {
            aB_TRANS.GetComponent<ArrowComponent>().TurnOnSprite();
        }
    }

    /// <summary>
    /// Clear the arrow body position and turn off;
    /// </summary>
    private void ClearArrow()
    {
        arrow_head_TRANS.position = Vector3.zero;
        arrow_head_TRANS.rotation = Quaternion.identity;
        arrow_head_TRANS.GetComponent<ArrowComponent>().TurnOffSprite();
        foreach (Transform aB_TRANS in arrow_body_TRANSs)
        {
            aB_TRANS.GetComponent<ArrowComponent>().TurnOffSprite();
            aB_TRANS.position = Vector3.zero;
            aB_TRANS.rotation = Quaternion.identity;
        }
    }

    /// <summary>
    /// Calculate the arrow body scale;
    /// </summary>
    private float ArrowBodyScaleCal(float init_scale, float final_scale, int index, int n)
    {
        float progress = (float)index / (float)n;
        return Mathf.Lerp(init_scale, final_scale, progress);
    }
}
