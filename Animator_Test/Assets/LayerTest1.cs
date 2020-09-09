using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerTest1 : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TextMesh TM1;
    [SerializeField] private TextMesh TM2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) { animator.SetTrigger("NextStep"); }
    }
}
