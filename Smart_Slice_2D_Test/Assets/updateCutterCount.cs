using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateCutterCount : MonoBehaviour
{
    Text text;

    public GameObject slice;
    public GameObject GameOverCanvas;
    public GameObject currentPercentageCanvas;

    int cutterCount = 3;
    bool isWin =false;

    void Start() { 
        text = gameObject.GetComponent<Text>(); 
        text.text = "You can still cut " + cutterCount +" times"; 
    }

    // Update is called once per frame
    void Update()
    {
        cutterCount = slice.GetComponent<Slicer2DController>().cutterCount;
        isWin = currentPercentageCanvas.GetComponent<updateCurrentPercentage>().isWin;
        if (cutterCount < 0 && !isWin) {
            GameOverCanvas.SetActive(true);
        }
        text.text = "You can still cut " + cutterCount +" times"; 
    }
}
