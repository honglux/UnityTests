using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum_Controller;

/// <summary>
/// GameMode in InGameScene;
/// </summary>
[RequireComponent(typeof(Animator))]
public class IGGM : MonoBehaviour
{
    public static IGGM IS;

    public const float Pooper_reward_amount = -1.0f;    //Default pooper reward amount;
    public const int Invalid_chest_id = -1; //Default invalid chest id;
    public const int Deno_button_soundi = 1;    //Sound clip index for the denomination button;
    public const int Play_button_soundi = 0;    //Sound clip index for the play button;

    [SerializeField] private AudioClip[] button_clips;  //Audio clips for buttons;
    [SerializeField] private AudioSource button_AS; //Audio source for buttons;

    private float chestg_scale; //Scale of the chest group;
    private List<Vector3> chestg_pos_list;  //Chest group position list;

    //Game data;
    private float curr_deno;    //Current denomination;
    private int curr_deno_i;    //Current denomination index;
    private float curr_balance; //Current balance;
    private float curr_win; //Track the current win amount;
    private bool receive_Mcast; //whether should reveive the mouse cast;
    private int hovering_id;    //id that the mouse is current hovering;
    private GameModeState curr_GMstate; //current game mode state; 
    private float predict_multi;   //Predicted multiplier;
    private float[] chest_reward_arr;   //Dynamic reward for each chest array;
    private float total_pred_reward;   //Total predicted reward;
    private int curr_chest_reward_index;    //Current chest reward index;
    private float[] chest_ani_tier_arr; //Used for chest animation change tier;
    private IEnumerator closeallchest_ani_coro; //Coroutine for close all chests animation;
    private int transition_finished_cnt;    //transition count of finish state; till 9 for example;

    private void Awake()
    {
        IS = this;

        chestg_scale = 1.0f;
        chestg_pos_list = new List<Vector3>();
        curr_deno = 0.0f;
        curr_deno_i = 0;
        curr_balance = 0.0f;
        receive_Mcast = false;
        hovering_id = -1;
        curr_GMstate = GameModeState.Default;
        predict_multi = 0.0f;
        total_pred_reward = 0.0f;
        curr_chest_reward_index = 0;
        curr_win = 0;
        chest_reward_arr = new float[0];
        chest_ani_tier_arr = new float[0];
        closeallchest_ani_coro = null;
        transition_finished_cnt = 0;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (receive_Mcast) { receiv_mouse_cast(); }
        if (Input.GetMouseButtonDown(0)) { leftMouseEvent(); }
    }

    #region private methods;

    /// <summary>
    /// Handle left mouse button event;
    /// </summary>
    private void leftMouseEvent()
    {
        switch(curr_GMstate)
        {
            case GameModeState.ChooseChest:
                open_chest();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Open chest action;
    /// </summary>
    private void open_chest()
    {
        ChestGroup temp = null;
        if (curr_GMstate == GameModeState.ChooseChest)
        {
            if (hovering_id == Invalid_chest_id || curr_chest_reward_index >= chest_reward_arr.Length)
            { return; }
            float reward = chest_reward_arr[curr_chest_reward_index];
            temp = IGRC.IS.ChestGroup_TRANS_dict[hovering_id].GetComponent<ChestGroup>();
            if (temp == null || !temp.OpenChest(reward, reward == Pooper_reward_amount,
                text_animation: GSD.IS.Use_chest_text_ani, ani_tier: chest_ani_tier_arr))
            {
                return;
            }
            curr_win += Mathf.Max(reward, 0.0f);
            ++curr_chest_reward_index;
            if (reward == Pooper_reward_amount) { finish_choose_chest(); }
        }
    }

    /// <summary>
    /// Warpup the choose chest state;
    /// </summary>
    private void finish_choose_chest()
    {
        GetComponent<Animator>().SetTrigger(SD.AniNextTrigger);
    }

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
        temp_TRANS.parent = IGRC.IS.ChestGroup_parent;
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
        init_chest_reward_arr();
    }

    /// <summary>
    /// Init the chest reward arr;
    /// </summary>
    private void init_chest_reward_arr()
    {
        chest_reward_arr = new float[GSD.IS.VP_Cpos_XY_arr.Length];
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
        curr_balance += curr_win;
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
                if(hovering_id != Invalid_chest_id)
                {
                    IGRC.IS.ChestGroup_TRANS_dict[hovering_id].GetComponent<ChestGroup>().MouseUnHover();
                }
                hit_chest_group.MouseHover();
            }
            hovering_id = hit_chest_group.Cid;
        }
        else
        {
            if (hovering_id != Invalid_chest_id)
            {
                IGRC.IS.ChestGroup_TRANS_dict[hovering_id].GetComponent<ChestGroup>().MouseUnHover();
            }
            hovering_id = Invalid_chest_id;
        }
    }

    /// <summary>
    /// Bet the denomitaion amount;
    /// </summary>
    private void bet_deno(float deno)
    {
        curr_balance -= deno;
        IGUIC.IS.Update_CB_RO(curr_balance);
    }


    private void generate_multiplier()
    {
        int curr_tieri = choose_tier_index();
        predict_multi = choose_multiplier(curr_tieri);
        total_pred_reward = curr_deno * predict_multi;
    }

    /// <summary>
    /// Choose the tier index;
    /// </summary>
    /// <returns></returns>
    private int choose_tier_index()
    {
        int tier_random = Random.Range(0, 100);
        int tempperc = 0;
        int curr_tieri = 0;
        foreach (KeyValuePair<int, int> perc_index in GSD.IS.Multi_perc_tierind_dict)
        {
            tempperc = perc_index.Key;
            if (tier_random >= tempperc % 100 && tier_random <= tempperc / 100)
            {
                curr_tieri = perc_index.Value;
                break;
            }
        }

        return curr_tieri;
    }

    /// <summary>
    /// Choose the multiplier based on the tier;
    /// </summary>
    /// <param name="tieri"></param>
    /// <returns></returns>
    private int choose_multiplier(int tieri)
    {
        int[] multi_arr = GSD.IS.Multiplier_2darr[tieri].Multiplier_list;
        int multiplier_random = Random.Range(0, multi_arr.Length);
        int curr_multi = multi_arr[multiplier_random];
        return curr_multi;
    }

    /// <summary>
    /// Generate the chest reward;
    /// </summary>
    private void generate_chest_reward()
    {
        init_chest_reward_arr();
        Debug.Log("Current predicted reward " + total_pred_reward.ToString());
        float increament = (float)GSD.IS.MiniChestIncreament;
        int valid_Cnumber = Random.Range(1, GSD.IS.AverageValidChestUpbound + 1);
        Debug.Log("Valid predicted chest number " + valid_Cnumber);
        float total_multi_increament = total_pred_reward / increament;
        int total_multi_incre_int = Mathf.FloorToInt(total_multi_increament);
        if (total_multi_incre_int != total_multi_increament) 
        {
            Debug.LogError("total_multi_incre_int calculation error!");
            return;
        }
        int average_multi_incre = Mathf.CeilToInt(total_multi_incre_int / valid_Cnumber);
        float temp_reward = 0.0f;
        int temp_multi_incre = 0, multi_incre_sum = 0;
        bool finished = false;
        int i = 0;
        if(total_multi_incre_int != 0)
        {
            for (; i < chest_reward_arr.Length - 2 && !finished; ++i)
            {
                temp_multi_incre = Random.Range(1, average_multi_incre);
                if (temp_multi_incre + multi_incre_sum >= total_multi_incre_int)
                {
                    temp_multi_incre = total_multi_incre_int - multi_incre_sum;
                    finished = true;
                }
                temp_reward = increament * temp_multi_incre;
                chest_reward_arr[i] = temp_reward;
                multi_incre_sum += temp_multi_incre;
            }
            if (multi_incre_sum < total_multi_incre_int)
            {
                chest_reward_arr[i++] = (total_multi_incre_int - multi_incre_sum) * increament;
            }
        }
        chest_reward_arr[i] = Pooper_reward_amount;
        Debug.Log("Predicted muliplier for this run " + predict_multi.ToString());
        Utilities.print_arr<float[], float>(chest_reward_arr, str: "Predicted reward for each chest ");
    }

    /// <summary>
    /// Generate the chest animation tier with dollars based on multiplier;
    /// </summary>
    /// <returns></returns>
    private void generate_Cani_tier(float deno)
    {
        chest_ani_tier_arr = new float[GSD.IS.C_ani_tier_multi_arr.Length];
        for (int i = 0; i < GSD.IS.C_ani_tier_multi_arr.Length; ++i) 
        {
            chest_ani_tier_arr[i] = deno * GSD.IS.C_ani_tier_multi_arr[i];
        }
        Utilities.print_arr<float[], float>(chest_ani_tier_arr, str: "Chest tier threshold ");
    }

    private void Cchestdata_reset()
    {
        curr_win = 0;
        curr_chest_reward_index = 0;
    }

    /// <summary>
    /// Do all the cleanups for choose chest state;
    /// </summary>
    private void cleanup_chest_toCC_state()
    {
        close_all_chests();
    }

    private void close_all_chests()
    {
        if(!GSD.IS.Use_closeAllChests_ani)
        {
            foreach (KeyValuePair<int, Transform> id_TRANSs in IGRC.IS.ChestGroup_TRANS_dict)
            {
                id_TRANSs.Value.GetComponent<ChestGroup>().CloseChest();
                ++transition_finished_cnt;
            }
        }
        else
        {
            if (closeallchest_ani_coro != null) { StopCoroutine(closeallchest_ani_coro); }
            closeallchest_ani_coro = closeallchests_ani_coroutine();
            StartCoroutine(closeallchest_ani_coro);
        }
    }

    private IEnumerator closeallchests_ani_coroutine()
    {
        foreach (KeyValuePair<int, Transform> id_TRANSs in IGRC.IS.ChestGroup_TRANS_dict)
        {
            id_TRANSs.Value.GetComponent<ChestGroup>().CloseChest();
            ++transition_finished_cnt;
            yield return new WaitForSeconds(GSD.IS.Closeallchest_timegap);
        }
    }

    private void play_BGM()
    {
        if (BGMController.IS == null) 
        { Debug.LogError("BGMController loading error!"); return; }
        BGMController.IS.Play_BGM();
    }

    /// <summary>
    /// Play button sound based on the index of the clip;
    /// </summary>
    /// <param name="index"></param>
    private void play_button_sound(int index)
    {
        if (index >= button_clips.Length) 
        { Debug.LogError("Button clips loading error!"); return; }
        button_AS.PlayOneShot(button_clips[index]);
    }

    #endregion

    #region public methods;

    public void Increase_denomination()
    {
        ++curr_deno_i;
        curr_deno_i = Mathf.Min(GSD.IS.Denomination_arr.Length - 1, curr_deno_i);
        update_denomination(GSD.IS.Denomination_arr[curr_deno_i]);
        play_button_sound(Deno_button_soundi);
    }

    public void Decrease_denomination()
    {
        --curr_deno_i;
        curr_deno_i = Mathf.Max(0, curr_deno_i);
        update_denomination(GSD.IS.Denomination_arr[curr_deno_i]);
        play_button_sound(Deno_button_soundi);
    }

    public void Play_button()
    {
        IGUIC.IS.ToggleButtonLock_ChooseChest();
        GetComponent<Animator>().SetTrigger(SD.AniPlayTrigger);
        play_button_sound(Play_button_soundi);
    }

    public void Exit_button()
    {
        Application.Quit();
    }

    /// <summary>
    /// Called when we open the chest to show current win animation;
    /// </summary>
    /// <param name="amount"></param>
    public void Update_cur_win(float amount)
    {
        IGUIC.IS.Update_LW_RO(curr_win);
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
        play_BGM();
    }

    /// <summary>
    /// Start the calling state;
    /// </summary>
    public void ToCalling()
    {
        curr_GMstate = GameModeState.Calling;
        toggle_lock_CGroups(true);
        callingState_reset();
    }
    
    /// <summary>
    /// Start the CallingToCChestTrans state;
    /// </summary>
    public void ToCallingToCCTrans()
    {
        transition_finished_cnt = 0;
        bet_deno(curr_deno);
        generate_multiplier();
        generate_chest_reward();
        generate_Cani_tier(curr_deno);
        cleanup_chest_toCC_state();
    }

    public void UpdateCallingToCCTrans()
    {
        if (transition_finished_cnt >= GSD.IS.VP_Cpos_XY_arr.Length) 
        { GetComponent<Animator>().SetTrigger(SD.AniNextTrigger); }
    }

    /// <summary>
    /// Start tje Choose Chest state;
    /// </summary>
    public void ToChooseChest()
    {
        curr_GMstate = GameModeState.ChooseChest;
        //toggle_lock_CGroups(false);
        toggle_mouse_cast(true);
        Cchestdata_reset();
        IGUIC.IS.ChooseChestUI_reset();
    }

    public void ToCChestToCallingTrans()
    {
        GetComponent<Animator>().SetTrigger(SD.AniNextTrigger);
    }

    #endregion

}
