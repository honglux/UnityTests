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
    private bool receive_Mcast; //whether should reveive the mouse cast;
    private int hovering_id;    //id that the mouse is current hovering;

    private void Awake()
    {
        IS = this;

        chestg_scale = 1.0f;
        chestg_pos_list = new List<Vector3>();
        curr_deno = 0.0f;
        curr_deno_i = 0;
        curr_balance = 0.0f;
        last_win = 0.0f;
        receive_Mcast = false;
        hovering_id = -1;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (receive_Mcast) { receiv_mouse_cast(); }
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
        int tempid = 0;
        foreach (Vector3 Cpos in chestg_pos_list)
        {
            spawn_single_CG(Cpos, tempid);
            ++tempid;
        }
    }

    /// <summary>
    /// Spawn a single chest group;
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="id"></param>
    private void spawn_single_CG(Vector3 pos, int id)
    {
        Transform temp_TRANS = Instantiate(IGRC.IS.ChestGroup_PRE, pos, Quaternion.identity).transform;
        temp_TRANS.localScale *= chestg_scale;
        IGRC.IS.ChestGroup_TRANS_dict.Add(id, temp_TRANS);
        ChestGroup chest_group = temp_TRANS.GetComponent<ChestGroup>();
        chest_group.Init_CG(id);
    }

    /// <summary>
    /// Initialize tje game data;
    /// </summary>
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
        IGUIC.IS.Update_CD_RO(curr_deno);
        IGUIC.IS.Toggle_playbutton_lock(check_playable());
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

    /// <summary>
    /// Set the lock state of the chest groups;
    /// </summary>
    /// <param name="lockstate"></param>
    private void toggle_lock_CGroups(bool lockstate)
    {
        foreach(KeyValuePair<int, Transform> id_CTRANS in IGRC.IS.ChestGroup_TRANS_dict)
        {
            toggle_lock_singleCGroup(id_CTRANS.Value.GetComponent<ChestGroup>(), lockstate);
        }
    }

    /// <summary>
    /// Set the lock state of a single chest group;
    /// </summary>
    /// <param name="lockstate"></param>
    private void toggle_lock_singleCGroup(ChestGroup chest_group, bool lockstate)
    {
        if (lockstate) { chest_group.Lock_Cgroup(); }
        else { chest_group.Unlock_Cgroup(); }
    }

    /// <summary>
    /// Set the mouse ray cast state;
    /// </summary>
    /// <param name="casting"></param>
    private void toggle_mouse_cast(bool casting)
    {
        MouseRayCast.IS.Toggle_casting(casting);
        receive_Mcast = casting;
    }

    /// <summary>
    /// Excute the mouse raycast system;
    /// Whether we should put this to update or fixed-update, or adjust the MouseRayCast class, 
    /// is a debatable question, both of them have pros and cons;
    /// </summary>
    private void receiv_mouse_cast()
    {
        RaycastHit hit_info = MouseRayCast.IS.Get_hitinfo();
        ChestGroup hit_chest_group = null;
        if (MouseRayCast.IS.hit_flag && hit_info.transform.CompareTag(SD.ChestGroupTriggerTag) &&
            hit_info.transform.GetComponent<GeneralTrigger>() != null)
        {
            
            hit_chest_group = hit_info.transform.GetComponent<GeneralTrigger>().
                Get_root_TRANS().GetComponent<ChestGroup>();
            if(hit_chest_group.Cid != hovering_id)
            {
                if(hovering_id != -1)
                {
                    IGRC.IS.ChestGroup_TRANS_dict[hovering_id].GetComponent<ChestGroup>().MouseUnHover();
                }
                hit_chest_group.MouseHover();
            }
            hovering_id = hit_chest_group.Cid;
        }
        else
        {
            if (hovering_id != -1)
            {
                IGRC.IS.ChestGroup_TRANS_dict[hovering_id].GetComponent<ChestGroup>().MouseUnHover();
            }
            hovering_id = -1;
        }
    }

    #endregion

    #region public methods;

    public void Increase_denomination()
    {
        ++curr_deno_i;
        curr_deno_i = Mathf.Min(GSD.IS.Denomination_arr.Length - 1, curr_deno_i);
        update_denomination(GSD.IS.Denomination_arr[curr_deno_i]);
    }

    public void Decrease_denomination()
    {
        --curr_deno_i;
        curr_deno_i = Mathf.Max(0, curr_deno_i);
        update_denomination(GSD.IS.Denomination_arr[curr_deno_i]);
    }

    public void Play_button()
    {
        IGUIC.IS.ToggleButtonLock_ChooseChest();
        GetComponent<Animator>().SetTrigger(SD.AniPlayTrigger);
    }

    #endregion


    #region StateMachine;

    /// <summary>
    /// Star init state;
    /// </summary>
    public void ToInit()
    {
        chestg_scale_cal();
        chestg_pos_cal();
        spawn_chestgroups();
        IGRC.IS.CBGTemplate.Self_destroy();
        init_gamedata();
        GetComponent<Animator>().SetTrigger(SD.AniNextTrigger);
    }

    /// <summary>
    /// Start the calling state;
    /// </summary>
    public void ToCalling()
    {
        toggle_lock_CGroups(true);
        callingState_reset();
    }
    
    /// <summary>
    /// Start the CallingToCChestTrans state;
    /// </summary>
    public void ToCallingToCCTrans()
    {
        GetComponent<Animator>().SetTrigger(SD.AniNextTrigger);
    }

    /// <summary>
    /// Start tje Choose Chest state;
    /// </summary>
    public void ToChooseChest()
    {
        toggle_lock_CGroups(false);
        toggle_mouse_cast(true);
    }

    #endregion

}
