using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentTest : MonoBehaviour
{
    public float timer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //add_component();

    }

    private void add_component()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 2.0f;
            Debug.Log("component added");
            Debug.Log("null " + (gameObject.GetComponent<ComponentTest2>() == null));
            if (gameObject.GetComponent<ComponentTest2>() == null)
            {
                gameObject.AddComponent<ComponentTest2>();
            }

        }
    }

    public void call_test()
    {
        Debug.Log("call_test called!!!");
        transform.position = new Vector3(0.0f, 100.0f, 0.0f);
    }
}
