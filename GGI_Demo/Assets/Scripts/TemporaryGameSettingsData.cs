using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Temporary solution for loading game settings data. Can replace it with Json or XML files.
/// </summary>
public class TemporaryGameSettingsData : MonoBehaviour
{
    //Chest group;
    public Vector2[] VP_Cpos_XY_arr;    //Chest positions from viewport scales;
    public float VP_Csize;  //Chests group size (half from center) based on the viewport scale;
    public float CG_zoffset;    //Z offset of the chest group;
    //UI;
    public bool Use_text_animation; //Whether to animate the text;
    public float Text_ani_time; //Animation time for changing the text;
    //Logic Data;
    public float[] Denomination_arr;    //Possibile denominations;
    public float Init_balance;  //Initial balance;

}
