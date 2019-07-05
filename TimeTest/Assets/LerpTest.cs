using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    [SerializeField] private TextMesh TM1;
    [SerializeField] private TextMesh TM2;
    [SerializeField] private TextMesh TM3;

    private Vector3 start = new Vector3(1.0f, 0.0f, 0.0f);
    private Vector3 end = new Vector3(100.0f, 0.0f, 0.0f);
    private Vector3 lerp_test1;
    private Vector3 lerp_test2;
    private Vector3 lerp_test3;
    private float zero;

    // Start is called before the first frame update
    void Start()
    {
        this.lerp_test1 = new Vector3();
        this.lerp_test2 = new Vector3();
        this.lerp_test3 = new Vector3();
        this.zero = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        zero += Time.deltaTime;
        lerp_test1 = Vector3.Lerp(start, end, zero);
        lerp_test2 = Vector3.Lerp(start, end, 0.5f);
        lerp_test3 = Vector3.Lerp(start, end, 0.9f);
        TM1.text = lerp_test1.ToString();
        TM2.text = zero.ToString();
        TM3.text = lerp_test3.ToString();
    }
}
