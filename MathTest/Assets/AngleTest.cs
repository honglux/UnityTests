using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleTest : MonoBehaviour
{
    [SerializeField] private Transform OBJ1;
    [SerializeField] private Transform OBJ2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos1 = new Vector3(OBJ1.position.x, 0.0f, OBJ1.position.z);
        Vector3 pos2 = new Vector3(OBJ2.position.x, 0.0f, OBJ2.position.z);
        Debug.Log(Vector3.Angle(pos1, pos2));
    }
}
