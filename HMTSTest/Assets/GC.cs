using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GC : MonoBehaviour
{
    public Animator GCAnimator;
    public TextMesh TM1;
    public TextMesh TM2;
    public TextMesh TM3;

    public int trial_iter { get; set; }
    public int loop_iter { get; set; }
    public int section_number { get; set; }

    private Dictionary<int, int> AC_results;
    private Dictionary<int, int> AC_results_wrong;
    private Dictionary<int, int> AC_left_results;
    private Dictionary<int, int> AC_left_results_wrong;
    private Dictionary<int, int> AC_right_results;
    private Dictionary<int, int> AC_right_results_wrong;
    private int MLH_first;
    private bool MLH_left_stop_flag;
    private bool MLH_right_stop_flag;
    private int curr_acuity_size;
    private bool head_left;
    private int AD_repeat_index;
    private int A_delay_index;
    private float curr_A_delay;
    private int AD_left_right;
    private int AD_right_right;
    private int head_time_counter;

    public static GC IS;


    private static class MLHData
    {
        public static int single_repeat_num;
        public static int double_repeat_num;
        public static Queue<int> pre_size;

        public static int get_queue_maxsize()
        {
            int res = 0;
            foreach (int s in pre_size)
            {
                res = Math.Max(res, s);
            }
            return res;
        }

        public static void clear(ref int first)
        {
            single_repeat_num = 0;
            double_repeat_num = 0;
            pre_size = new Queue<int>();
            first = 0;
        }
    }

    private static class MLHLeftData
    {
        public static int single_repeat_num;
        public static int double_repeat_num;
        public static Queue<int> pre_size;

        public static int get_queue_maxsize()
        {
            int res = 0;
            foreach (int s in pre_size)
            {
                res = Math.Max(res, s);
            }
            return res;
        }

        public static void clear()
        {
            single_repeat_num = 0;
            double_repeat_num = 0;
            pre_size = new Queue<int>();
        }
    }

    private static class MLHRightData
    {
        public static int single_repeat_num;
        public static int double_repeat_num;
        public static Queue<int> pre_size;

        public static int get_queue_maxsize()
        {
            int res = 0;
            foreach (int s in pre_size)
            {
                res = Math.Max(res, s);
            }
            return res;
        }

        public static void clear()
        {
            single_repeat_num = 0;
            double_repeat_num = 0;
            pre_size = new Queue<int>();
        }
    }

    private void Awake()
    {
        IS = this;

        this.AC_results = new Dictionary<int,int>();
        this.AC_results_wrong = new Dictionary<int, int>();
        this.AC_left_results = new Dictionary<int,int>();
        this.AC_left_results_wrong = new Dictionary<int,int>();
        this.AC_right_results = new Dictionary<int,int>();
        this.AC_right_results_wrong = new Dictionary<int,int>();
    }

    private void Start()
    {
        DD_clear_MLH();
    }

    private void Update()
    {
        update_text();

        if (Input.GetKeyDown(KeyCode.Q)) { speed_passed(true); }
        else if (Input.GetKeyDown(KeyCode.W)) { speed_passed(false); }
        else if (Input.GetKeyDown(KeyCode.A)) { controller_input(true); }
        else if (Input.GetKeyDown(KeyCode.S)) { controller_input(false); }
    }

    private void update_text()
    {
        TM3.text = "L:" + Print_dict(ref AC_left_results) + "\n" +
            "LW:" + Print_dict(ref AC_left_results_wrong) + "\n" +
            "R:" + Print_dict(ref AC_right_results) + "\n" +
            "RW:" + Print_dict(ref AC_right_results_wrong);
    }

    private static string Print_dict(ref Dictionary<int,int> dict)
    {
        string res = "";
        foreach(KeyValuePair<int,int> kv in dict)
        {
            res += kv.Key.ToString() + "~" + kv.Value.ToString() + "|";
        }
        return res;
    }

    private static string Print_array(ref float[] arr)
    {
        string res = "";
        foreach(float num in arr)
        {
            res += num.ToString() + "|";
        }
        return res;
    }

    private void controller_input(bool correct)
    {
        turn_off_TM();
        record_AC(correct);
        GCAnimator.SetTrigger("Controller");
    }

    private void turn_off_TM()
    {
        TM1.transform.GetComponent<MeshRenderer>().enabled = false;
        TM2.transform.GetComponent<MeshRenderer>().enabled = false;
    }

    public void ToStartTrial()
    {

        if (true)
        {
            if (dyna_change_delay())
            {
                to_next_section();
                return;
            }
        }

        if (trial_iter < 0)
        {
            trial_iter++;
        }
        else
        {
            trial_iter++;
        }

        GCAnimator.SetTrigger("Next");
    }

    private bool dyna_change_delay()
    {
        int a = 1;
        switch (a)
        {
            case 0:
                return false;
            case 1:
                return DD_next_MLH();

        }
        return false;
    }

    private bool DD_next_MLH()
    {
        DD_dynamic_change_AC();
        if (DD_MLH_judge())
        {
            DD_clear_MLH();
            return DD_next_delay();
        }
        return false;
    }

    private bool DD_next_delay()
    {
        AD_repeat_index = 0;
        A_delay_index++;
        curr_A_delay += 0.08f;
        if (curr_A_delay > 0.72f || stop_by_threshold())
        {
            return true;
        }
        AD_left_right = 0;
        AD_right_right = 0;
        head_time_counter = 0;
        return false;
    }

    private bool stop_by_threshold()
    {
        return ((AD_left_right >= 7 && AD_right_right >= 7) &&
                (head_time_counter >= 9));
    }

    private bool DD_MLH_judge()
    {
        (bool, int) temp_res = (false, 0);
        if (true)
        {
            if (head_left)
            {
                temp_res = MLH_left_check_stop();
                if (temp_res.Item1) { MLH_left_stop_flag = true; }
            }
            else
            {
                temp_res = MLH_right_check_stop();
                if (temp_res.Item1) { MLH_right_stop_flag = true; }
            }
            if (MLH_left_stop_flag && MLH_right_stop_flag) { return true; }
        }
        else { return MLH_check_stop().Item1; }

        return false;
    }

    private (bool, int) MLH_check_stop()
    {
        int[] queue_temp = MLHData.pre_size.ToArray();
        if (queue_temp.Length > 0 && curr_acuity_size == queue_temp[queue_temp.Length - 1])
        { MLHData.single_repeat_num++; }
        else
        { MLHData.single_repeat_num = 0; }
        if (MLHData.pre_size.Contains(curr_acuity_size))
        { MLHData.double_repeat_num++; }
        else
        {
            MLHData.double_repeat_num = 0;
            //MLHData.pre_size.Enqueue(curr_acuity_size);
        }
        if (queue_temp.Length == 0 || curr_acuity_size != queue_temp[queue_temp.Length - 1])
        {
            MLHData.pre_size.Enqueue(curr_acuity_size);
            while (MLHData.pre_size.Count > 2) { MLHData.pre_size.Dequeue(); }
        }
        if (MLHData.single_repeat_num > 3)
        { return (true, curr_acuity_size); }
        if (MLHData.double_repeat_num > 5)
        { return (true, MLHData.get_queue_maxsize()); }
        return (false, 0);
    }

    private (bool, int) MLH_left_check_stop()
    {
        int[] queue_temp = MLHLeftData.pre_size.ToArray();
        if (queue_temp.Length > 0 && curr_acuity_size == queue_temp[queue_temp.Length - 1])
        { MLHLeftData.single_repeat_num++; }
        else
        { MLHLeftData.single_repeat_num = 0; }
        if (MLHLeftData.pre_size.Contains(curr_acuity_size))
        { MLHLeftData.double_repeat_num++; }
        else
        {
            MLHLeftData.double_repeat_num = 0;
            //MLHLeftData.pre_size.Enqueue(curr_acuity_size);
        }
        if (queue_temp.Length == 0 || curr_acuity_size != queue_temp[queue_temp.Length - 1])
        {
            MLHLeftData.pre_size.Enqueue(curr_acuity_size);
            while (MLHLeftData.pre_size.Count > 2) { MLHLeftData.pre_size.Dequeue(); }
        }
        if (MLHLeftData.single_repeat_num > 3)
        { return (true, curr_acuity_size); }
        if (MLHLeftData.double_repeat_num > 5)
        { return (true, MLHLeftData.get_queue_maxsize()); }
        return (false, 0);
    }

    private (bool, int) MLH_right_check_stop()
    {
        int[] queue_temp = MLHRightData.pre_size.ToArray();
        if (queue_temp.Length > 0 && curr_acuity_size == queue_temp[queue_temp.Length - 1])
        { MLHRightData.single_repeat_num++; }
        else
        { MLHRightData.single_repeat_num = 0; }
        if (MLHRightData.pre_size.Contains(curr_acuity_size))
        { MLHRightData.double_repeat_num++; }
        else
        {
            MLHRightData.double_repeat_num = 0;
            //MLHRightData.pre_size.Enqueue(curr_acuity_size);
        }
        if (queue_temp.Length == 0 || curr_acuity_size != queue_temp[queue_temp.Length - 1])
        {
            MLHRightData.pre_size.Enqueue(curr_acuity_size);
            while (MLHRightData.pre_size.Count > 2) { MLHRightData.pre_size.Dequeue(); }
        }
        if (MLHRightData.single_repeat_num > 3)
        { return (true, curr_acuity_size); }
        if (MLHRightData.double_repeat_num > 5)
        { return (true, MLHRightData.get_queue_maxsize()); }
        return (false, 0);
    }

    private int DD_dynamic_change_AC()
    {
        if (true && false)
        {
            MLH_first++;
            curr_acuity_size = MLH_actuiy_cal();
            if (MLH_first <= 2 && curr_acuity_size < 9) { curr_acuity_size++; }
            set_acuity_size(curr_acuity_size);
        }
        return curr_acuity_size;
    }

    private void set_acuity_size(int size)
    {
        curr_acuity_size = size;
    }

    private int MLH_actuiy_cal()
    {
        float Lmax = 0.0f;
        int max_size_p1 = 9 + 1;
        float[] lgit = new float[max_size_p1];
        float L = 0.0f;
        int res = 0;
        //pl.optotypeSize[0] = pl.eps;
        for (int i = 0; i < max_size_p1; i++)
        {
            for (int j = 0; j < max_size_p1; j++)
            {
                lgit[j] = 0.125f + (0.75f / (1.0f + Mathf.Pow((float)i / (float)j, 2)));
            }
            L = 1.0f;
            for (int k = 0; k < max_size_p1; k++)
            {
                L *= Mathf.Pow(lgit[k], get_ac_result(k)) *
                    Mathf.Pow(1 - lgit[k], get_ac_result(k, wrong: true));
            }
            if (L > Lmax)
            {
                Lmax = L;
                res = i;
            }
        }
        return res;
    }

    private int get_ac_result(int size, bool wrong = false)
    {
        if (!wrong) { return AC_results.ContainsKey(size) ? AC_results[size] : 0; }
        else { return AC_results_wrong.ContainsKey(size) ? AC_results_wrong[size] : 0; }
    }

    private void to_next_section()
    {
        loop_iter = -1;
        trial_iter = -1;
        section_number++;
        //GCAnimator.SetTrigger("Finished");

    }

    private void DD_clear_MLH()
    {
        MLHData.clear(ref MLH_first);
        MLHLeftData.clear();
        MLHRightData.clear();
        AC_results.Clear();
        AC_results_wrong.Clear();
        AC_left_results.Clear();
        AC_left_results_wrong.Clear();
        AC_right_results.Clear();
        AC_right_results_wrong.Clear();
        MLH_left_stop_flag = false;
        MLH_right_stop_flag = false;
    }

    private void speed_passed(bool left)
    {
        head_left = left;
        DD_gs_change_AC(head_left);
        show_acuity();
        GCAnimator.SetTrigger("Turn");
    }

    private void show_acuity()
    {
        if (head_left) 
        {
            TM1.text = curr_acuity_size.ToString();
            TM1.transform.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            TM2.text = curr_acuity_size.ToString();
            TM2.transform.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void DD_gs_change_AC(bool left)
    {
        if (true && true)
        {
            if (left) { DD_MLH_change(true); }
            else { DD_MLH_change(false); }
        }
    }

    private int DD_MLH_change(bool left)
    {
        MLH_first++;
        curr_acuity_size = MLH_actuiy_cal_dir(left);
        if (MLH_first <= 2 && curr_acuity_size < 9) { curr_acuity_size++; }
        Debug.Log(MLH_first.ToString() + "!!!!!" + curr_acuity_size.ToString());
        set_acuity_size(curr_acuity_size);
        return curr_acuity_size;
    }

    private int MLH_actuiy_cal_dir(bool left)
    {
        float Lmax = 0.0f;
        int max_size_p1 = 9 + 1;
        float[] lgit = new float[max_size_p1];
        float L = 0.0f;
        int res = 0;
        //pl.optotypeSize[0] = pl.eps;
        string s = "";
        string s2 = "";
        for (int i = 0; i < max_size_p1; i++)
        {
            for (int j = 0; j < max_size_p1; j++)
            {
                lgit[j] = 0.125f + (0.75f / (1.0f + Mathf.Pow((float)i / (float)j, 2)));
            }
            s2 = Print_array(ref lgit);
            L = 1.0f;
            for (int k = 0; k < max_size_p1; k++)
            {
                L *= Mathf.Pow(lgit[k], get_ac_result(k, left, wrong: false)) *
                    Mathf.Pow(1 - lgit[k], get_ac_result(k, left, wrong: true));
            }
            if (L > Lmax)
            {
                Lmax = L;
                res = i;
            }
            s += i.ToString() + "~" + L.ToString() + "|";
            //Debug.Log("s2 " + s2);
        }
        Debug.Log("s " + s);
        Debug.Log("res:" + res);
        return res;
    }

    private int get_ac_result(int size, bool left, bool wrong = false)
    {
        if (left)
        {
            if (!wrong) { return AC_left_results.ContainsKey(size) ? AC_left_results[size] : 0; }
            else { return AC_left_results_wrong.ContainsKey(size) ? AC_left_results_wrong[size] : 0; }
        }
        else
        {
            if (!wrong) { return AC_right_results.ContainsKey(size) ? AC_right_results[size] : 0; }
            else { return AC_right_results_wrong.ContainsKey(size) ? AC_right_results_wrong[size] : 0; }
        }

    }

    private void record_AC(bool result)
    {
        if (!AC_results.ContainsKey(curr_acuity_size))
        { AC_results.Add(curr_acuity_size, 0); }
        if (!AC_results_wrong.ContainsKey(curr_acuity_size))
        { AC_results_wrong.Add(curr_acuity_size, 0); }
        if (result)
        { AC_results[curr_acuity_size]++; }
        else
        { AC_results_wrong[curr_acuity_size]++; }
        if (head_left) { record_AC_dir(result, ref AC_left_results, ref AC_left_results_wrong); }
        else { record_AC_dir(result, ref AC_right_results, ref AC_right_results_wrong); }
    }

    private void record_AC_dir(bool result, ref Dictionary<int, int> right_dict,
        ref Dictionary<int, int> wrong_dict)
    {
        if (!right_dict.ContainsKey(curr_acuity_size))
        { right_dict.Add(curr_acuity_size, 0); }
        if (!wrong_dict.ContainsKey(curr_acuity_size))
        { wrong_dict.Add(curr_acuity_size, 0); }
        if (result)
        { right_dict[curr_acuity_size]++; }
        else
        { wrong_dict[curr_acuity_size]++; }
    }


}
