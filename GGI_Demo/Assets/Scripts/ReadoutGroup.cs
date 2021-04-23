using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadoutGroup : MonoBehaviour
{

    [SerializeField] protected TextMeshProUGUI readout_text;
    [SerializeField] [TextArea] protected string init_text;
    [SerializeField] private string num_format;

    private float readout_num;

    private void Awake()
    {
        readout_num = 0.0f;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Change the text based on the initial text;
    /// </summary>
    /// <param name="s"></param>
    public virtual void Change_text(string s)
    {
        readout_text.text = init_text + s;
    }

    public virtual void Change_text(float num)
    {
        readout_text.text = init_text + num.ToString("F2");
    }

    public virtual void Change_text(float num, string format)
    {
        readout_text.text = init_text + num.ToString(format);
    }

    public virtual void Set_format(string format)
    {
        num_format = format;
    }

    /// <summary>
    /// Update the readout number;
    /// </summary>
    /// <param name="num">Number</param>
    /// <param name="use_ani">Use text animation;</param>
    public virtual void Update_number(float num, bool use_ani = false)
    {
        readout_num = num;
        if (!use_ani) { Change_text(num); }
        else { }
    }
}

