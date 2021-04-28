using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Temporary solution for loading game settings data. Can replace it with Json or XML files.
/// </summary>
public class TemporaryGameSettingsData : MonoBehaviour
{
    [Header("Chest Group")]
    public Vector2[] VP_Cpos_XY_arr;    //Chest positions from viewport scales;
    public float VP_Csize;  //Chests group size (half from center) based on the viewport scale;
    public float CG_zoffset;    //Z offset of the chest group;
    public bool Use_chest_text_ani; //Whether to animate the text from chest group;
    public int[] C_ani_tier_multi_arr; //Chest animation tier list in multiplier;
    [Header("UI")]
    public bool Use_text_animation; //Whether to animate the text;
    public float Text_ani_time; //Animation time for changing the text;
    public float Text_ani_frenquency;   //The frenquency of animation;
    [Header("Logic Data")]
    public float[] Denomination_arr;    //Possibile denominations;
    public float Init_balance;  //Initial balance;
    public UtilityClasses.TierMulti_list[] Multiplier_arr;  //Multiplier 2d list; row: tier, col: real multiplier among this tier;
    public float MiniChestIncreament;   //Minimun chest reward;
    public int AverageValidChestUpbound;    //The Upbound to radomize the chest valid number; The actual number will be expended, so this number is close to the average number;
    public bool Use_closeAllChests_ani;   //Whether to animate close all chests;

    //Not showing in the inspector since it is a little tidious to do that; Will be possibile to fix it if necessary;
    //Multiplier dictionary <percentage, tier index>; Percentage format, highbound * 100 + lowbound;
    public Dictionary<int, int> Multi_perc_tierind_dict = new Dictionary<int, int>()
    {
        { 4900, 0 },
        { 7950, 1 },
        { 9480, 2 },
        { 9995, 3 }
    };

}
