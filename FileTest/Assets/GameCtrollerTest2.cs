using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFB;

public class GameCtrollerTest2 : MonoBehaviour {

    public TextMesh FilePath;

    private string path;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void openfile()
    {
        path = StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false)[0];

        FilePath.text = path;
    }
}
