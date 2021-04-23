using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    public System.Action<UIButtonColliderIndexes> ButtonHoved { get; set; }
    public System.Action PushButton { get; set; }
    public Transform Controller_TRANS { get; set; }

    [SerializeField] protected NormalStick NS_script;
    [SerializeField] protected Transform C_Buttons_TRANS;
    [SerializeField] protected Transform U_Buttons_TRANS;
    [SerializeField] protected Transform D_Buttons_TRANS;
    [SerializeField] protected Transform L_Buttons_TRANS;
    [SerializeField] protected Transform R_Buttons_TRANS;

    [SerializeField] private Color Hoved_color;

    private Color C_color;
    private Color U_color;
    private Color D_color;
    private Color L_color;
    private Color R_color;
    protected UIButtonColliderIndexes curr_index;
    protected UIButtonColliderIndexes last_index;

    virtual protected void Awake()
    {
        //Debug.Log("Awake");
        this.ButtonHoved = null;
        this.Controller_TRANS = null;
        this.PushButton = null;
    }

    virtual protected void Start()
    {
        ButtonHoved += hove_detected;
        PushButton += push_detected;

        this.C_color = C_Buttons_TRANS.GetComponent<MeshRenderer>().material.color;
        this.U_color = U_Buttons_TRANS.GetComponent<MeshRenderer>().material.color;
        this.D_color = D_Buttons_TRANS.GetComponent<MeshRenderer>().material.color;
        this.L_color = L_Buttons_TRANS.GetComponent<MeshRenderer>().material.color;
        this.R_color = R_Buttons_TRANS.GetComponent<MeshRenderer>().material.color;
        this.curr_index = 0;
        this.last_index = 0;

        hove_detected(UIButtonColliderIndexes.C);
    }

    virtual protected void push_detected()
    {

    }

    virtual protected void hove_detected(UIButtonColliderIndexes index)
    {
        curr_index = index;
        delight_button();
        highlight_button();
        change_button_text();
        last_index = curr_index;
    }

    virtual protected void highlight_button()
    {
        switch(curr_index)
        {
            case UIButtonColliderIndexes.C:
                C_Buttons_TRANS.GetComponent<MeshRenderer>().material.color = Hoved_color;
                break;
            case UIButtonColliderIndexes.U:
                U_Buttons_TRANS.GetComponent<MeshRenderer>().material.color = Hoved_color;
                break;
            case UIButtonColliderIndexes.D:
                D_Buttons_TRANS.GetComponent<MeshRenderer>().material.color = Hoved_color;
                break;
            case UIButtonColliderIndexes.L:
                L_Buttons_TRANS.GetComponent<MeshRenderer>().material.color = Hoved_color;
                break;
            case UIButtonColliderIndexes.R:
                R_Buttons_TRANS.GetComponent<MeshRenderer>().material.color = Hoved_color;
                break;
        }
    }

    virtual protected void delight_button()
    {
        switch(last_index)
        {
            case UIButtonColliderIndexes.C:
                C_Buttons_TRANS.GetComponent<MeshRenderer>().material.color = C_color;
                break;
            case UIButtonColliderIndexes.U:
                U_Buttons_TRANS.GetComponent<MeshRenderer>().material.color = U_color;
                break;
            case UIButtonColliderIndexes.D:
                D_Buttons_TRANS.GetComponent<MeshRenderer>().material.color = D_color;
                break;
            case UIButtonColliderIndexes.L:
                L_Buttons_TRANS.GetComponent<MeshRenderer>().material.color = L_color;
                break;
            case UIButtonColliderIndexes.R:
                R_Buttons_TRANS.GetComponent<MeshRenderer>().material.color = R_color;
                break;
        }
    }

    virtual protected void change_button_text()
    {

    }
}

public enum UIButtonColliderIndexes { C, U, D, L, R, DUL, DUR, DDL, DDR };