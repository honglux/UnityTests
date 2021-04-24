using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestGroup : MonoBehaviour
{
    [SerializeField] private Transform panel_TRANS;
    [Header("Info")]
    [SerializeField] private Sprite closed_panel_sprite;
    [SerializeField] private Sprite hovering_panel_sprite;
    [SerializeField] private Sprite[] opened_panel_sprites;

    public int Cid { get; private set; }    //Chest id;
    public bool Lock_state { get; private set; }    //lock state of this group;

    private void Awake()
    {
        Cid = 0;
        Lock_state = false;
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
    /// Initialize the chest group;
    /// </summary>
    public void Init_CG(int _id)
    {
        Cid = _id;
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
        panel_TRANS.GetComponent<SpriteRenderer>().sprite = hovering_panel_sprite;
    }

    /// <summary>
    /// Unhover the panel;
    /// </summary>
    public void MouseUnHover()
    {
        if (Lock_state) { return; }
        panel_TRANS.GetComponent<SpriteRenderer>().sprite = closed_panel_sprite;
    }
}
