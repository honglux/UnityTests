using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneTest2 : MonoBehaviour
{
    GameObject GO = null;

    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2.0f)
        {
            GO = GameObject.Find("CloneTest2_T");
            GO = Instantiate(GO, GO.transform.position + 
                                new Vector3(0.0f, 0.0f, 1.0f), Quaternion.identity);
            GO.name = "AAA";

            timer = 0.0f;
        }
        
    }
}
