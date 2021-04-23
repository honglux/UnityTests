using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI controller in InGameScene;
/// </summary>
public class IGUIC : MonoBehaviour
{
    public static IGUIC IS;

    [Header("UI compnents")]
    [SerializeField] private ReadoutGroup curr_balance_ROG; //Current balance readout group;
    [SerializeField] private LastWinReadoutGroup last_win_ROG; //Last win readout group;
    [SerializeField] private ReadoutGroup curr_deno_ROG; //Current denomination readout group;
    [SerializeField] private Button play_button;
    [SerializeField] private Button Deno_decre_button;  //Denomination decrease button;
    [SerializeField] private Button Deno_incre_button;  //Denomination increase button;


    private void Awake()
    {
        IS = this;
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

    #endregion

    #region public methods;

    /// <summary>
    /// Update the UI for each calling statement
    /// </summary>
    /// <param name="post_curr_bala">Current balance after add the last win</param>
    /// <param name="last_win"></param>
    public void CallingUI_reset(float post_curr_bala)
    {
        ToggleButtonLock_Calling();
        last_win_ROG.Change_to_first_init();
        Update_CB_RO(post_curr_bala);
    }

    /// <summary>
    /// Set the lock state of the buttons, in calling state;
    /// </summary>
    public void ToggleButtonLock_Calling()
    {
        Toggle_deno_decr_button(true);
        Toggle_deno_incr_button(true);
    }

    /// <summary>
    /// Toggle the play button;
    /// </summary>
    /// <param name="enable">Enable state</param>
    public void Toggle_playbutton(bool enable)
    {
        play_button.interactable = enable;
    }

    /// <summary>
    /// Toggle the denomination decrease button;
    /// </summary>
    /// <param name="enable"></param>
    public void Toggle_deno_decr_button(bool enable)
    {
        play_button.interactable = enable;
    }

    /// <summary>
    /// Toggle the denomination increase button;
    /// </summary>
    /// <param name="enable"></param>
    public void Toggle_deno_incr_button(bool enable)
    {
        play_button.interactable = enable;
    }

    /// <summary>
    /// Update the current balance readout number;
    /// </summary>
    /// <param name="curr_balan"></param>
    public void Update_CB_RO(float curr_balan)
    {
        curr_balance_ROG.Update_number(curr_balan, use_ani: GSD.IS.Use_text_animation);
    }

    /// <summary>
    /// Update the last win readout number;
    /// </summary>
    /// <param name="last_win"></param>
    public void Update_LW_RO(float last_win)
    {
        last_win_ROG.Update_number(last_win, use_ani: GSD.IS.Use_text_animation);
    }

    /// <summary>
    /// Update the current denomination number;
    /// </summary>
    /// <param name="curr_deno"></param>
    public void Update_CD_RO(float curr_deno)
    {
        curr_deno_ROG.Update_number(curr_deno, use_ani: false);
    }

    #endregion
}
