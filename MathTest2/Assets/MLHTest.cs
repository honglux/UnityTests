using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLHTest : MonoBehaviour
{
    private static class MLHData
    {
        public static int single_repeat_num;
        public static int double_repeat_num;
        public static Queue<int> pre_size;
    }

    private int curr_acuity_size;
    private Dictionary<int, int> AC_results;
    private Dictionary<int, int> AC_results_wrong;
    private int state;

    public TextMesh TM;
    public TextMesh TM2;
    public TextMesh TM3;

    private void Awake()
    {
        AC_results = new Dictionary<int, int>();
        AC_results_wrong = new Dictionary<int, int>();
        state = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        clean_MLH_data();
        state = 1;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 1:
                MLH_change_acuity();
                state = 2;
                break;
            case 2:
                if(Input.GetKeyDown(KeyCode.A)) { AC(true); state = 1; }
                if (Input.GetKeyDown(KeyCode.S)) { AC(false); state = 1; }
                break;
        }
        update_text();
    }

    private void update_text()
    {
        TM.text = curr_acuity_size.ToString() + " | " + MLHData.single_repeat_num.ToString() + " | " + MLHData.double_repeat_num.ToString();
        TM2.text = "";
        foreach (int s in MLHData.pre_size)
        {
            TM2.text += " | " + s.ToString();
        }
    }

    private void AC(bool result)
    {
        if (!AC_results.ContainsKey(curr_acuity_size))
        { AC_results.Add(curr_acuity_size, 0); }
        if (!AC_results_wrong.ContainsKey(curr_acuity_size))
        { AC_results_wrong.Add(curr_acuity_size, 0); }
        if (result)
        { AC_results[curr_acuity_size]++; }
        else
        { AC_results_wrong[curr_acuity_size]++; }
    }

    private void clean_MLH_data()
    {
        MLHData.single_repeat_num = 0;
        MLHData.double_repeat_num = 0;
        MLHData.pre_size = new Queue<int>();
    }

    private void show_MLH(int size)
    {
        TM3.text = "!!!!!";
    }

    private bool MLH_change_acuity()
    {
        curr_acuity_size = MLH_actuiy_cal();
        (bool, int) res = MLH_check_stop();
        if (res.Item1)
        {
            show_MLH(res.Item2);
        }
        return res.Item1;
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
        { MLHData.double_repeat_num = 0; }
        if (queue_temp.Length == 0 || curr_acuity_size != queue_temp[queue_temp.Length - 1])
        {
            MLHData.pre_size.Enqueue(curr_acuity_size);
            while (MLHData.pre_size.Count > 2) { MLHData.pre_size.Dequeue(); } 
        }
        if (MLHData.single_repeat_num > 3)
        { return (true, curr_acuity_size); }
        if (MLHData.double_repeat_num > 15)
        { return (true, get_queue_maxsize()); }
        return (false, 0);
    }

    private int get_queue_maxsize()
    {
        int res = 0;
        foreach (int s in MLHData.pre_size)
        {
            res = Mathf.Max(res, s);
        }
        return res;
    }

    private int MLH_actuiy_cal()
    {
        float Lmax = 0.0f;
        int max_size_p1 = 10 + 1;
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
}
