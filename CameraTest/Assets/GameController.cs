using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    List<string> display_list = new List<string>() { "0","1", "2", "3", "4", "5" };

    public TextMesh text1;
    public Dropdown drop_down1;
    public Dropdown drop_down2;

    public Camera camera1;
    public Camera camera2;
    private bool cameraflag = false;

    private float timer = 3.0f;

	// Use this for initialization
	void Start () {
        //Debug.Log("displays connected: " + Display.displays.Length);
        //// Display.displays[0] is the primary, default display and is always ON.
        //// Check if additional displays are available and activate each.
        //if (Display.displays.Length > 1)
        //{
        //    Debug.Log("Display.displays.Length > 1");
        //    Display.displays[1].Activate();
        //}

        //if (Display.displays.Length > 2)
        //    Display.displays[2].Activate();

        drop_down1.ClearOptions();
        drop_down2.ClearOptions();
        drop_down1.AddOptions(display_list);
        drop_down2.AddOptions(display_list);

    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Display " + Display.displays);
        //Debug.Log("main " + Display.main);
        //Debug.Log("Display.displays[0] " + Display.displays[0]);

        //text1.text = Display.displays.ToString();

        //List<string> test1 = new List<string>();
        //foreach (Display disp in Display.displays)
        //{
        //    test1.Add(disp.ToString());
        //}
        //Debug.Log("test1 "+ test1);

        //List<string> test1 = new List<Display>(Display.displays);


        //drop_down1.ClearOptions();
        //drop_down1.AddOptions();

        timer -= Time.deltaTime;

        if(timer <=0)
        {
            //exchange_cameras();
            timer = 3.0f;
        }
    }

    private void exchange_cameras()
    {
        if(cameraflag)
        {
            camera1.targetDisplay = 0;
            camera2.targetDisplay = 1;
            cameraflag = false;
        }
        else
        {
            camera1.targetDisplay = 1;
            camera2.targetDisplay = 0;
            cameraflag = true;
        }

        
    }

    public void change_cameras()
    {
        int dd1 = int.Parse(drop_down1.captionText.text);
        //Debug.Log("dd1 " + dd1);
        int dd2 = int.Parse(drop_down2.captionText.text);

        camera1.targetDisplay = dd1;
        camera2.targetDisplay = dd2;
    }
}
