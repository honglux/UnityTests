using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITTAssist : MonoBehaviour
{
    [SerializeField] private GameObject IT_OBJ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A " + InstanceTest.Instance.transform.name);
            Destroy(InstanceTest.Instance.gameObject);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(IT_OBJ, Vector3.zero, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("S " + InstanceTest.Instance.a);
        }
    }
}
