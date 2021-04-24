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
    public UtilityClasses.TierMulti_list[] Multiplier_arr;  //Multiplier 2d list; row: tier, col: real multiplier among this tier;

    //Not showing in the inspector since it is a little tidious to do that; Will be possibile to fix it if necessary;
    //Multiplier dictionary <percentage, tier index>; Percentage format, highbound * 100 + lowbound;
    public Dictionary<int, int> Multi_perc_tierind_dict = new Dictionary<int, int>()
    {
        { 4900, 0 },
        { 7950, 1 },
        { 9480, 2 },
        { 9995, 3 }
    };
    public float MiniChestIncreament;   //Minimun chest reward;
    public int AverageValidChestUpbound;  //The Upbound to radomize the chest valid number; The actual number will be expended, so this number is close to the average number;
}
