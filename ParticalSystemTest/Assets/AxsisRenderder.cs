using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxsisRenderder : MonoBehaviour
{
    [SerializeField] private LineRenderer X_line;
    [SerializeField] private LineRenderer Y_line;
    [SerializeField] private Transform X_start;
    [SerializeField] private Transform X_end;
    [SerializeField] private Transform Y_start;
    [SerializeField] private Transform Y_end;

    // Start is called before the first frame update
    void Start()
    {
        X_line.SetPositions(new Vector3[] { X_start.position, X_end.position });
        Y_line.SetPositions(new Vector3[] { Y_start.position, Y_end.position });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
