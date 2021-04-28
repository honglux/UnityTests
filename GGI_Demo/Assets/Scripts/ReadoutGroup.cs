using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadoutGroup : MonoBehaviour
{

    [SerializeField] protected TextMeshProUGUI readout_text;
    [SerializeField] [TextArea] protected string init_text;
    [SerializeField] protected string num_format;

    protected float readout_num;
    protected IEnumerator text_ani_coro;

    private void Awake()
    {
        readout_num = 0.0f;
        text_ani_coro = null;
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

    /// <summary>
    /// Change the text purely, should not be called if you want to change the readout_num;
    /// </summary>
    /// <param name="num"></param>
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
        if (!use_ani) 
        {
            readout_num = num;
            Change_text(num);
        }
        else 
        {
            if (text_ani_coro != null) { StopCoroutine(text_ani_coro); }
            text_ani_coro = text_animation_coro(num, GSD.IS.UI_text_ani_time,
                GSD.IS.UI_text_ani_frenquency);
            StartCoroutine(text_ani_coro);
        }
    }

    /// <summary>
    /// Coroutine to do text animation;
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator text_animation_coro(float num, float ani_time, float ani_freq)
    {
        float gap = (num - readout_num) / ani_time * ani_freq;
        float time_sum = 0.0f;
        while (time_sum < ani_time)
        {
            readout_num += gap;
            Change_text(readout_num);
            yield return new WaitForSeconds(ani_freq);
            time_sum += ani_freq;
        }
        readout_num = num;
        Change_text(num);
    }
}

