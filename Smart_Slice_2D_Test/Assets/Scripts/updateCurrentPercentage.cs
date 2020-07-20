using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateCurrentPercentage : MonoBehaviour
{
    Text text;
    int currentPercentage = 0;
    public bool isWin = false;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>(); 
        text.text = " Current Percentage: " + currentPercentage +"%";         
    }

    // Update is called once per frame
    void Update()
    {
        var objects = GameObject.FindGameObjectsWithTag("Sliceable");
        var objectCount = objects.Length;
        foreach (var obj in objects) {
            if (obj.transform.position.y <= -10) {
                currentPercentage += 20;
                Destroy(obj);
            }
        }
        text.text = " Current Percentage: " + currentPercentage +"%";         
        if (currentPercentage >= 80)
            isWin = true;       
    }
}
