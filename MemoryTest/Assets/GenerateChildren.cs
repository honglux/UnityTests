using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChildren : MonoBehaviour
{
    [SerializeField] private GameObject Child_Prefab;
    [SerializeField] private int NUM;

    private bool start;

    private void Awake()
    {
        this.start = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) { Destroy(gameObject); }
        if (Input.GetKeyDown(KeyCode.S)) { start = true; }
        if (Input.GetKeyDown(KeyCode.D)) { start = false; }

        if(start)
        {
            Instantiate(Child_Prefab, transform);
        }
    }
}
