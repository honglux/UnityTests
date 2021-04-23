using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadoutParent : MonoBehaviour
{
    [SerializeField] private TextMeshPro readout_text;
    [SerializeField] private string init_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Change_text(string s)
    {
        readout_text.text = init_text + s;
    }

    public virtual void Change_text(float num)
    {
        readout_text.text = init_text + num.ToString("F2");
    }

    public virtual void Change_text(int num)
    {
        readout_text.text = init_text + num.ToString();
    }
}
