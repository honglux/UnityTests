using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameMode in InGameScene;
/// </summary>
[RequireComponent(typeof(Animator))]
public class IGGM : MonoBehaviour
{
    public static IGGM IS;

    private float chestg_scale; //Scale of the chest group;
    private List<Vector3> chestg_pos_list;  //Chest group position list;

    //Game data;
    private float curr_deno;    //Current denomination;
    private int curr_deno_i;    //Current denomination index;
    private float curr_balance; //Current balance;
    private float last_win; //Last win;

    private void Awake()
    {
        IS = this;

        chestg_scale = 1.0f;
        chestg_pos_list = new List<Vector3>();
        curr_deno = 0.0f;
        curr_deno_i = 0;
        curr_balance = 0.0f;
        last_win = 0.0f;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region private methods;

    /// <summary>
    /// Calculate the chest group scale;
    /// </summary>
    private void chestg_scale_cal()
    {
        float xVPreal = IGRC.IS.CBGTemplate.Get_x_viewport() - 0.5f;
        float xVPexpect = GSD.IS.VP_Csize;
        chestg_scale = xVPexpect / xVPreal;
    }

    private void chestg_pos_cal()
    {
        Vector3 tempVP = new Vector3();
        Vector3 tempres = new Vector3();
        foreach (Vector2 VPpos in GSD.IS.VP_Cpos_XY_arr)
        {
            tempVP = (Vector3)VPpos;
            tempVP.z = GSD.IS.CG_zoffset;
            tempres = Camera.main.ViewportToWorldPoint(tempVP);
            chestg_pos_list.Add(tempres);
        }
    }

    /// <summary>
    /// Spawn all chest groups based on the position; 
    /// </summary>
    private void spawn_chestgroups()
    {
        foreach (Vector3 Cpos in chestg_pos_list)
        {
            spawn_single_CG(Cpos);
        }
    }

    private void spawn_single_CG(Vector3 pos)
    {
        Transform temp_TRANS = Instantiate(IGRC.IS.ChestGroup_PRE, pos, Quaternion.identity).transform;
        temp_TRANS.localScale *= chestg_scale;
        IGRC.IS.ChestGroup_TRANS_list.Add(temp_TRANS);
    }

    private void init_gamedata()
    {
        curr_balance = GSD.IS.Init_balance;
    }

    /// <summary>
    /// Reset the game objects for the calling state;
    /// </summary>
    public void callingState_reset()
    {
        callingdata_reset();
        callingUI_reset();
    }

    /// <summary>
    /// Reset the game data for the calling state;
    /// </summary>
    private void callingdata_reset()
    {
        curr_balance += last_win;
        if (GSD.IS.Denomination_arr.Length == 0) 
        {
            Debug.LogError("Denomination_arr is unset!");
            return;
        }
        curr_deno_i = 0;
        update_denomination(GSD.IS.Denomination_arr[curr_deno_i]);
    }

    /// <summary>
    /// Run when denomination changed;
    /// </summary>
    /// <param name="deno"></param>
    private void update_denomination(float deno)
    {
        curr_deno = deno;
        IGUIC.IS.Toggle_playbutton(check_playable());
    }

    /// <summary>
    /// Check if the player could play the round;
    /// </summary>
    /// <returns></returns>
    private bool check_playable()
    {
        if(curr_deno == 0.0f || curr_balance < curr_deno) { return false; }
        return true;
    }

    /// <summary>
    /// Reset the UI for calling state;
    /// </summary>
    private void callingUI_reset()
    {
        IGUIC.IS.CallingUI_reset(curr_balance);
    }

    #endregion

    #region public methods;

    public void Increase_denomination()
    {
        ++curr_deno_i;
        curr_deno_i = Mathf.Min(GSD.IS.Denomination_arr.Length, curr_deno_i);
        update_denomination(GSD.IS.Denomination_arr[curr_deno_i]);
    }

    public void Decrease_denomination()
    {
        --curr_deno_i;
        curr_deno_i = Mathf.Max(0, curr_deno_i);
        update_denomination(GSD.IS.Denomination_arr[curr_deno_i]);
    }

    #endregion


    #region StateMachine;

    public void ToInit()
    {
        chestg_scale_cal();
        chestg_pos_cal();
        spawn_chestgroups();
        IGRC.IS.CBGTemplate.Self_destroy();
        init_gamedata();
        GetComponent<Animator>().SetTrigger(SD.AniNextTrigger);
    }

    public void ToCalling()
    {
        callingState_reset();
    }

    #endregion

}
