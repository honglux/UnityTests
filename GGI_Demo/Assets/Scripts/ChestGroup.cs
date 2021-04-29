using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestGroup : MonoBehaviour
{
    [SerializeField] private Transform panel_TRANS;
    [SerializeField] private Transform chest_model_TRANS;
    [SerializeField] private Transform chest_text_TRANS;
    [SerializeField] private Transform chest_content_TRANS;
    [SerializeField] private AudioSource loop_AS;
    [SerializeField] private AudioSource oneshot_AS;
    [SerializeField] private AudioClip[] tier_ACs;
    [SerializeField] private AudioClip pooper_AC;
    [Header("Info")]
    [SerializeField] private Sprite closed_panel_sprite;
    [SerializeField] private Sprite hovering_panel_sprite;
    [SerializeField] private Sprite[] opened_panel_sprites;
    [SerializeField] private Color text_init_color;
    [SerializeField] private Color[] opened_text_colors;
    [SerializeField] private float text_ani_time;
    [SerializeField] private float text_ani_freq;
    [SerializeField] private float ani_deltascale;
    [SerializeField] private float ani_scale_freq;

    public int Cid { get; private set; }    //Chest id;
    public bool Lock_state { get; private set; }    //lock state of this group;

    private float reward;
    private Vector3 init_scale;
    private bool use_animation;
    bool is_pooper;
    private float chest_ani_amount; //Chest reward amount while in animation;
    private IEnumerator chest_text_ani_coro;    //chest text animation amount;
    private IEnumerator chest_scale_ani_coro;   //chest scale animation amount;
    private float[] animation_tier;   //animation tier from IGGM;

    private void Awake()
    {
        Cid = 0;
        Lock_state = false;
        use_animation = false;
        chest_ani_amount = 0.0f;
        chest_text_ani_coro = null;
        chest_scale_ani_coro = null;
        init_scale = Vector3.one;
        animation_tier = new float[0];
        is_pooper = false;
        reward = 0.0f;
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
    /// Show text animation coroutine; This will also call the tier animation;
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="ani_tier">Animation tier, which is in dollars, should be pre-calculated</param>
    /// <returns></returns>
    private IEnumerator show_text_ani_coro(float amount, float ani_time, float ani_freq, float[] ani_tier)
    {
        int next_tier = 0;
        chest_ani_amount = 0.0f;
        chest_text_TRANS.GetComponent<ChestText>().Show_text(chest_ani_amount);
        int total_step = Mathf.FloorToInt(ani_time / ani_freq);
        float gap = amount / ani_time * ani_freq;
        int curr_step = 0;
        play_coin_sound();
        while (curr_step < total_step)
        {
            chest_ani_amount += gap;
            Update_text(chest_ani_amount);
            if (check_ani_tier(chest_ani_amount, ani_tier, next_tier))
            { change_ani_tier(ref next_tier); }
            ++curr_step;
            yield return new WaitForSeconds(ani_freq);
        }
        chest_ani_amount = amount;
        Update_text(chest_ani_amount);
        stop_coin_sound();
    }

    /// <summary>
    /// Check if animation tier need to change;
    /// </summary>
    /// <param name="_chest_ani_amount"></param>
    /// <param name="ani_tier"></param>
    /// <param name="next_tier"></param>
    private bool check_ani_tier(float _chest_ani_amount, float[] ani_tier, int next_tier)
    {
        if (next_tier >= ani_tier.Length || next_tier >= opened_panel_sprites.Length)
        { return false; }
        if (_chest_ani_amount >= ani_tier[next_tier])
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Change the animation tier;
    /// </summary>
    /// <param name="tier"></param>
    private void change_ani_tier(ref int next_tier)
    {
        if (next_tier < opened_panel_sprites.Length)
        {
            change_BG_sprite(opened_panel_sprites[next_tier]);
        }
        if (next_tier < opened_text_colors.Length)
        {
            change_text_color(opened_text_colors[next_tier]);
        }
        if (next_tier < tier_ACs.Length)
        {
            play_tier_sound(next_tier);
        }
        if (chest_scale_ani_coro != null)
        { StopCoroutine(chest_scale_ani_coro); }
        chest_scale_ani_coro = change_scale_ani_coro(ani_deltascale, ani_scale_freq);
        StartCoroutine(chest_scale_ani_coro);
        ++next_tier;
    }

    /// <summary>
    /// Animation to change scale based on tier;
    /// </summary>
    /// <param name="tier"></param>
    /// <returns></returns>
    private IEnumerator change_scale_ani_coro(float deltascale, float time_gap)
    {
        transform.localScale += new Vector3(deltascale, deltascale, 0.0f);
        yield return new WaitForSeconds(time_gap);
        transform.localScale -= 2 * new Vector3(deltascale, deltascale, 0.0f);
        yield return new WaitForSeconds(time_gap);
        transform.localScale = init_scale;
    }

    /// <summary>
    /// Change the background panel sprite;
    /// </summary>
    /// <param name="sprite"></param>
    private void change_BG_sprite(Sprite sprite)
    {
        panel_TRANS.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void change_text_color(Color color)
    {
        chest_text_TRANS.GetComponent<ChestText>().Change_color(color);
    }

    private void show_pooper()
    {
        chest_text_TRANS.GetComponent<ChestText>().Show_pooper();
        play_pooper_sound();
    }

    /// <summary>
    /// Clean objects and close the chest;
    /// </summary>
    private void clean_N_close_chest()
    {
        chest_ani_amount = 0.0f;
        animation_tier = new float[0];
        is_pooper = false;
        reward = 0.0f;
        turn_on_content();
        hide_text_N_pooper();
        change_BG_sprite(closed_panel_sprite);
        chest_model_TRANS.GetComponent<ChestModel>().CloseChest();
    }

    /// <summary>
    /// Hide the text;
    /// </summary>
    /// <param name="animation"></param>
    private void hide_text_N_pooper(bool animation = false)
    {
        chest_text_TRANS.GetComponent<ChestText>().Change_color(text_init_color);
        chest_text_TRANS.GetComponent<ChestText>().Hide_text();
        chest_text_TRANS.GetComponent<ChestText>().Hide_pooper();
    }

    /// <summary>
    /// Turn on the jewel;
    /// </summary>
    private void turn_on_content()
    {
        chest_content_TRANS.gameObject.SetActive(true);
    }

    /// <summary>
    /// Turn off the jewel;
    /// </summary>
    private void turn_off_content()
    {
        chest_content_TRANS.gameObject.SetActive(false);
    }

    /// <summary>
    /// Play the coin sound; This loops;
    /// </summary>
    private void play_coin_sound()
    {
        loop_AS.Play();
    }

    /// <summary>
    /// Stop the coin sound;
    /// </summary>
    private void stop_coin_sound()
    {
        loop_AS.Stop();
    }

    /// <summary>
    /// Player pooper sound;
    /// </summary>
    private void play_pooper_sound()
    {
        oneshot_AS.PlayOneShot(pooper_AC);
    }

    /// <summary>
    /// player tier sound based on the tier;
    /// </summary>
    /// <param name="tier"></param>
    private void play_tier_sound(int tier)
    {
        if (tier >= tier_ACs.Length) { return; }
        oneshot_AS.PlayOneShot(tier_ACs[tier]);
    }

    /// <summary>
    /// Initialize the chest group;
    /// </summary>
    public void Init_CG(int _id)
    {
        Cid = _id;
        init_scale = transform.localScale;
        Lock_Cgroup();
    }

    /// <summary>
    /// Lock this group;
    /// </summary>
    public void Lock_Cgroup()
    {
        Lock_state = true;
    }

    /// <summary>
    /// Unlock this group;
    /// </summary>
    public void Unlock_Cgroup()
    {
        Lock_state = false;
    }

    /// <summary>
    /// Excute when mouse is hovering the panel;
    /// </summary>
    public void MouseHover()
    {
        if (Lock_state) { return; }
        change_BG_sprite(hovering_panel_sprite);
    }

    /// <summary>
    /// Unhover the panel;
    /// </summary>
    public void MouseUnHover()
    {
        if (Lock_state) { return; }
        change_BG_sprite(closed_panel_sprite);
    }

    /// <summary>
    /// Open chest; pass in the reward amount;
    /// </summary>
    public bool OpenChest(float _reward, bool _ispooper, bool text_animation = false,
        float[] ani_tier = default(float[]))
    {
        if (Lock_state) { return false; }
        Lock_state = true;
        change_BG_sprite(hovering_panel_sprite);
        use_animation = text_animation;
        animation_tier = ani_tier;
        is_pooper = _ispooper;
        reward = _reward;
        if (is_pooper) { turn_off_content(); }
        chest_model_TRANS.GetComponent<ChestModel>().OpenChest();
        return true;
    }

    /// <summary>
    /// Close the chest, and reset other children objects;
    /// </summary>
    public void CloseChest()
    {
        clean_N_close_chest();
    }

    public void OpenChest_callback()
    {
        if (is_pooper) { show_pooper(); }
        else { Show_text(reward, animation: use_animation, ani_tier: animation_tier); }
        IGGM.IS.Update_cur_win(reward);
    }

    public void CloseChest_callback()
    {
        Lock_state = false;
    }

    /// <summary>
    /// Show the text of the chest;
    /// </summary>
    /// <param name="animation"></param>
    /// <param name="ani_tier">Pre calculated tier list</param>
    public void Show_text(float amount, bool animation = false, float[] ani_tier = default(float[]))
    {
        if (!animation) 
        { chest_text_TRANS.GetComponent<ChestText>().Show_text(amount); }
        else 
        {
            if (chest_text_ani_coro != null) { StopCoroutine(chest_text_ani_coro); }
            chest_text_ani_coro = show_text_ani_coro(amount, text_ani_time, text_ani_freq, ani_tier);
            StartCoroutine(chest_text_ani_coro);
        }
    }

    /// <summary>
    /// Update the text only;
    /// </summary>
    /// <param name="amount"></param>
    public void Update_text(float amount)
    {
        chest_text_TRANS.GetComponent<ChestText>().Update_text(amount);
    }
}
