using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIButton : MonoBehaviour
{
    [SerializeField] private GameObject Project_Prefab;

    [SerializeField] private int Number;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void button_pushed()
    {
        instantiate_project();
    }

    private void instantiate_project()
    {
        GameObject project_OBJ = Instantiate(Project_Prefab, transform.position,
                                Quaternion.identity);
        project_OBJ.GetComponent<TextMeshPro>().text = Number.ToString();
        project_OBJ.GetComponent<NumberProject>().start_move();
    }
}
