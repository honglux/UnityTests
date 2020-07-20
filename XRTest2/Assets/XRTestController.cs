using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRTestController : MonoBehaviour
{
    [SerializeField] private TextMesh TM;
    [SerializeField] private Test1 T1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //debug_out1();
        debug_out2();
        center();

    }

    private void debug_out1()
    {
        TM.text = T1.HS.ToString("F4") + " \t| " + T1.HAC.ToString("F4") + " \t| " + T1.HP.ToString("F4") + " | ";
    }

    private void debug_out2()
    {
        TM.text = T1.RightC_axis.ToString("F2") + "\t|" + T1.HS.ToString("F2") + " \t| " + 
            T1.HS2.ToString("F2") + "\t|" + T1.RightC_trigger.ToString("F2") + "\t|";
    }

    private void center()
    {
        if (T1.RightC_YButton2) { XRDeviceManager.recenter(); }
    }
}
