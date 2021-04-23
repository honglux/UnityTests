using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIButton : MonoBehaviour
{
    [SerializeField] private string Number;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change_number(string number)
    {
        Number = number;
        GetComponentInChildren<TextMeshPro>().text = number;
    }
}
