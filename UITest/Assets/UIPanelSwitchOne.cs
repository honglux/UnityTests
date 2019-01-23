using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPanelSwitchOne : UIPanel
{
    [SerializeField] private UseMode CurrUseMode;
    [SerializeField] private GameObject Project_Prefab;

    private ShootSystem SS_script;

    private SwtichOneButtons selected_button;
    private string new_text;

    protected override void Start()
    {
        base.Start();

        SS_script = GameObject.Find("ShootSystem").GetComponent<ShootSystem>();

        selected_button = 0;
    }

    protected override void push_detected()
    {
        switch(CurrUseMode)
        {
            case UseMode.Fight:
                instantiate_project();
                break;
            case UseMode.Shoot:
                change_shoot_text();
                break;
        }
        
    }

    private void change_shoot_text()
    {
        SS_script.str = new_text;
    }

    protected override void change_button_text()
    {
        new_text = ExampleStrDict.SO_example_dict[original_to_switchone()];
        switch (curr_index)
        {
            case UIButtonColliderIndexes.C:
                C_Buttons_TRANS.GetComponent<UIButton>().change_number(new_text);
                break;
            case UIButtonColliderIndexes.U:
                U_Buttons_TRANS.GetComponent<UIButton>().change_number(new_text);
                break;
            case UIButtonColliderIndexes.D:
                D_Buttons_TRANS.GetComponent<UIButton>().change_number(new_text);
                break;
            case UIButtonColliderIndexes.L:
                L_Buttons_TRANS.GetComponent<UIButton>().change_number(new_text);
                break;
            case UIButtonColliderIndexes.R:
                R_Buttons_TRANS.GetComponent<UIButton>().change_number(new_text);
                break;
        }
    }

    private SwtichOneButtons original_to_switchone()
    {
        switch(curr_index)
        {
            case UIButtonColliderIndexes.C:
                return SwtichOneButtons.C;
            //CU,LR,RU;
            case UIButtonColliderIndexes.U:
                switch(last_index)
                {
                    case UIButtonColliderIndexes.C:
                        return SwtichOneButtons.U;
                    case UIButtonColliderIndexes.L:
                        return SwtichOneButtons.LU;
                    case UIButtonColliderIndexes.R:
                        return SwtichOneButtons.RU;
                }
                break;
            //CD,LD,RD;
            case UIButtonColliderIndexes.D:
                switch (last_index)
                {
                    case UIButtonColliderIndexes.C:
                        return SwtichOneButtons.D;
                    case UIButtonColliderIndexes.L:
                        return SwtichOneButtons.LD;
                    case UIButtonColliderIndexes.R:
                        return SwtichOneButtons.RD;
                }
                break;
            //CL,UL,DL;
            case UIButtonColliderIndexes.L:
                switch (last_index)
                {
                    case UIButtonColliderIndexes.C:
                        return SwtichOneButtons.L;
                    case UIButtonColliderIndexes.U:
                        return SwtichOneButtons.UL;
                    case UIButtonColliderIndexes.D:
                        return SwtichOneButtons.DL;
                }
                break;
            //CR,UR,LR;
            case UIButtonColliderIndexes.R:
                switch (last_index)
                {
                    case UIButtonColliderIndexes.C:
                        return SwtichOneButtons.R;
                    case UIButtonColliderIndexes.U:
                        return SwtichOneButtons.UR;
                    case UIButtonColliderIndexes.D:
                        return SwtichOneButtons.DR;
                }
                break;
        }
        return SwtichOneButtons.C;
    }

    private void instantiate_project()
    {
        GameObject project_OBJ = Instantiate(Project_Prefab, transform.position,
                                Quaternion.identity);
        project_OBJ.GetComponent<TextMeshPro>().text = new_text;
        project_OBJ.GetComponent<NumberProject>().start_move(project_OBJ.transform.forward);
    }
}

public enum SwtichOneButtons { C, U, D, L, R, UL, UR, DL, DR, LU, LD, RU, RD };
public enum UseMode { Shoot,Fight};
