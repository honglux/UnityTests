using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastInsideTest : MonoBehaviour
{
    [SerializeField] private float max_dist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Test1();
    }

    private void Test1()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("!!!!!" + hit.transform);
        }
        else { Debug.Log("!!!!! Not hit !!!!!"); }
    }
}
