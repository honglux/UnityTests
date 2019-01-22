using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    [SerializeField] NormalStick NS_script;

    public Transform Controller_TRANS { get; set; }

    private void Awake()
    {
        this.Controller_TRANS = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void push_button()
    {
        NS_script.last_collider.GetComponent<UIButton>().button_pushed();
    }
}
