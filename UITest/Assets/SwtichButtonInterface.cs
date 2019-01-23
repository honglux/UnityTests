using System.Collections.Generic;
using System;

public static class SwtichButtonInterface
{

    public static Dictionary<int, Action> SOB_Functions;

    static System.Action U_function;
    static System.Action D_function;
    static System.Action L_function;
    static System.Action R_function;
    static System.Action UL_function;
    static System.Action UR_function;
    static System.Action DL_function;
    static System.Action DR_function;
    static System.Action LU_function;
    static System.Action LD_function;
    static System.Action RU_function;
    static System.Action RD_function;


    static SwtichButtonInterface()
    {
        U_function = null;
        D_function = null;
        L_function = null;
        R_function = null;
        UL_function = null;
        UR_function = null;
        DL_function = null;
        DR_function = null;
        LU_function = null;
        LD_function = null;
        RU_function = null;
        RD_function = null;


    }


}
