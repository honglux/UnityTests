using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;

public class SimpleFileBrowserTest : MonoBehaviour
{
    public string a = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void button()
    {
        SimpleFileBrowser.FileBrowser.ShowLoadDialog(
            (path) => { a = path; }, () => { }, false, null, "Load", "Select");
    }
}
