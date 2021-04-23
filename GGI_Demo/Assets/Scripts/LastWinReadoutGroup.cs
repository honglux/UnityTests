using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastWinReadoutGroup : ReadoutGroup
{
    [SerializeField] [TextArea] protected string init_text2;

    private string curr_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Change_text(string s)
    {
        readout_text.text = curr_text + s;
    }

    public override void Change_text(float num)
    {
        readout_text.text = curr_text + num.ToString("F2");
    }

    public override void Change_text(float num, string format)
    {
        readout_text.text = curr_text + num.ToString(format);
    }

    public void Change_to_first_init()
    {
        curr_text = init_text;
    }

    public void Change_to_second_init()
    {
        curr_text = init_text2;
    }
}
