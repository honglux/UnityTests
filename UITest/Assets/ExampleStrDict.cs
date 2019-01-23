using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExampleStrDict
{
    static public Dictionary<SwtichOneButtons, string> SO_example_dict;

    static ExampleStrDict()
    {
        SO_example_dict = new Dictionary<SwtichOneButtons, string>();

        SO_example_dict[SwtichOneButtons.C] = "0";
        SO_example_dict[SwtichOneButtons.U] = "1";
        SO_example_dict[SwtichOneButtons.D] = "2";
        SO_example_dict[SwtichOneButtons.L] = "3";
        SO_example_dict[SwtichOneButtons.R] = "4";
        SO_example_dict[SwtichOneButtons.UL] = "1+3";
        SO_example_dict[SwtichOneButtons.UR] = "1+4";
        SO_example_dict[SwtichOneButtons.DL] = "2+3";
        SO_example_dict[SwtichOneButtons.DR] = "2+4";
        SO_example_dict[SwtichOneButtons.LU] = "3+1";
        SO_example_dict[SwtichOneButtons.LD] = "3+2";
        SO_example_dict[SwtichOneButtons.RU] = "4+1";
        SO_example_dict[SwtichOneButtons.RD] = "4+2";
    }

}
