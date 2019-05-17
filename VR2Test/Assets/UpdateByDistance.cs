using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateByDistance : MonoBehaviour
{
    [SerializeField] private Transform LeftEye_TRANS;
    [SerializeField] private Transform RightEye_TRANS;
    [SerializeField] private Transform LeftTarget_TRANS;
    [SerializeField] private Transform RightTarget_TRANS;
    [SerializeField] private float Speed = 1.0f;

    private Vector3 left_eye_pos;
    private Vector3 right_eye_pos;
    private Vector3 left_target_pos;
    private Vector3 right_target_pos;

    // Start is called before the first frame update
    void Start()
    {
        this.left_eye_pos = LeftEye_TRANS.position;
        this.right_eye_pos = RightEye_TRANS.position;
        this.left_target_pos = LeftTarget_TRANS.position;
        this.right_target_pos = RightTarget_TRANS.position;
    }

    // Update is called once per frame
    void Update()
    {
        update_by_distance();
    }

    private void update_by_distance()
    {
        Vector3 left_dist = LeftEye_TRANS.position - left_eye_pos;
        Vector3 right_dist = RightEye_TRANS.position - right_eye_pos;

        LeftTarget_TRANS.position = left_target_pos + left_dist * Speed;
        RightTarget_TRANS.position = right_target_pos + right_dist * Speed;

    }

}
