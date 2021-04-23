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

    public Vector2[] VP_Cpos_XY_arr { get; private set; }    //Chest positions from viewport scales;
    public float VP_Csize { get; private set; }  //Chests group size (half from center) based on the viewport scale;
    public float CG_zoffset { get; private set; }   //Z offset of the chest group;
    public bool Use_text_animation { get; private set; } //Whether to animate the text;
    public float Text_ani_time { get; private set; } //Animation time for changing the text;
    public float[] Denomination_arr { get; private set; }   //Possibile denominations;
    public float Init_balance { get; private set; } //Initial balance;

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
        Use_text_animation = _TGSData.Use_text_animation;
        Text_ani_time = _TGSData.Text_ani_time;
        Denomination_arr = _TGSData.Denomination_arr;
        Init_balance = _TGSData.Init_balance;
    }
}
