using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    [SerializeField] private GameObject UIPanel_Prefab;
    [SerializeField] private Controller_Input CI_script;
    [SerializeField] private Transform Controller_TRANS;

    [SerializeField] private float UIPanelOffsetZ;

    private GameObject UIPanel_OBJ;

    private bool panel_open;

    private void Awake()
    {
        this.UIPanel_OBJ = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        CI_script.UISystemDown += UI_button_down;
        CI_script.UISystemUp += UI_button_up;

        this.UIPanelOffsetZ = 0.0f;
        this.panel_open = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UI_button_down()
    {
        //Debug.Log("UI_button_down");
        panel_open = true;
        instantiate_UIPanel();
    }

    private void UI_button_up()
    {
        //Debug.Log("UI_button_up");
        panel_open = false;
        close_panel();
    }

    private void instantiate_UIPanel()
    {
        UIPanel_OBJ = Instantiate(UIPanel_Prefab, 
                                transform.position + Controller_TRANS.forward * UIPanelOffsetZ,
                                Quaternion.identity);
        panel_rotation_fix();
        UIPanel_OBJ.GetComponent<UIPanel>().Controller_TRANS = Controller_TRANS;
    }

    private void close_panel()
    {
        if(UIPanel_OBJ != null)
        {
            UIPanel_OBJ.GetComponent<UIPanel>().push_button();
            Destroy(UIPanel_OBJ);
        }
    }

    private void panel_rotation_fix()
    {
        //Debug.Log("Controller_TRANS.rotation.y " + Controller_TRANS.rotation.y);
        //UIPanel_OBJ.transform.LookAt(Camera.main.transform);
        UIPanel_OBJ.transform.eulerAngles = new Vector3(10.0f,
                                                        Controller_TRANS.eulerAngles.y,
                                                        UIPanel_OBJ.transform.rotation.z);
        
    }


}
