using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  GameSettingsData;
/// </summary>
public class GSD : MonoBehaviour
{
    public static GSD IS;

    [SerializeField] private TemporaryGameSettingsData TGSData;

    //Chest group;
    public Vector2[] VP_Cpos_XY_arr { get; private set; }    //Chest positions from viewport scales; Also defines the total chest number;
    public float VP_Csize { get; private set; }  //Chests group size (half from center) based on the viewport scale;
    public float CG_zoffset { get; private set; }   //Z offset of the chest group;
    public bool Use_chest_text_ani { get; private set; }    //Whether to animate the text from chest group;
    public int[] C_ani_tier_multi_arr { get; private set; } //Chest animation tier list in multiplier;
    //UI
    public bool Use_UI_text_animation { get; private set; } //Whether to animate the text;
    public float UI_text_ani_time { get; private set; } //Animation time for changing the text;
    public float UI_text_ani_frenquency { get; private set; }   //The frenquency of animation;
    //Game data;
    public float[] Denomination_arr { get; private set; }   //Possibile denominations;
    public float Init_balance { get; private set; } //Initial balance;
    public Dictionary<int, int> Multi_perc_tierind_dict { get; private set; }   //Multiplier dictionary <percentage, tier index>; Percentage format, highbound * 100 + lowbound;
    public UtilityClasses.TierMulti_list[] Multiplier_2darr { get; private set; }  //Multiplier 2d list; row: tier, col: real multiplier among this tier;
    public float MiniChestIncreament { get; private set; }   //Minimun chest reward;
    public int AverageValidChestUpbound { get; private set; }   //The Upbound to radomize the chest valid number; The actual number will be expended, so this number is close to the average number;
    public bool Use_closeAllChests_ani { get; private set; }    //Whether to animate close all chests;

    private void Awake()
    {
        IS = this;

        VP_Csize = 0.0f;

        LoadGameSetting(TGSData);
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
    /// Replace this if using othre loading method;
    /// </summary>
    public void LoadGameSetting(TemporaryGameSettingsData _TGSData)
    {
        VP_Cpos_XY_arr = _TGSData.VP_Cpos_XY_arr;
        VP_Csize = _TGSData.VP_Csize;
        CG_zoffset = _TGSData.CG_zoffset;
        Use_UI_text_animation = _TGSData.Use_text_animation;
        UI_text_ani_time = _TGSData.Text_ani_time;
        Denomination_arr = _TGSData.Denomination_arr;
        Init_balance = _TGSData.Init_balance;
        Multiplier_2darr = _TGSData.Multiplier_arr;
        Multi_perc_tierind_dict = _TGSData.Multi_perc_tierind_dict;
        MiniChestIncreament = _TGSData.MiniChestIncreament;
        AverageValidChestUpbound = _TGSData.AverageValidChestUpbound;
        Use_chest_text_ani = _TGSData.Use_chest_text_ani;
        UI_text_ani_frenquency = _TGSData.Text_ani_frenquency;
        C_ani_tier_multi_arr = _TGSData.C_ani_tier_multi_arr;
        Use_closeAllChests_ani = _TGSData.Use_closeAllChests_ani;
    }
}
