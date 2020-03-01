using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class WorldToViewportTest : MonoBehaviour
{
    [SerializeField] private Camera Cam;
    [SerializeField] private Transform Target_TRANS;
    [SerializeField] private Text TM;
    [SerializeField] private Canvas Canv;
    [SerializeField] private Transform Convert_TRANS;
    [SerializeField] private int PixePos;
    [SerializeField] private string FileMame;

    private Dictionary<int, float> buf = new Dictionary<int, float>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        test2();
        if(Input.GetKeyDown(KeyCode.S))
        {
            write_file();
        }
    }

    private void test1()
    {
        Vector3 pos = world_to_canvas(Target_TRANS.position, Cam, Canv);
        TM.text = pos.ToString("F4");
        Convert_TRANS.GetComponent<RectTransform>().anchoredPosition = pos;
    }
    
    private void test2()
    {
        Vector3 v_pos = Cam.ScreenToWorldPoint(new Vector3(PixePos, 0.0f, 10.0f),
                        Camera.MonoOrStereoscopicEye.Mono);
        TM.text = v_pos.ToString("F4");
        buf[PixePos] = v_pos.x;
        Target_TRANS.position = v_pos + Vector3.up * 3.0f;
    }

    private void write_file()
    {
        StreamWriter file;
        try
        {
            // create log file if it does not already exist. Otherwise open it for appending new trial
            file = new StreamWriter(FileMame);

            foreach(KeyValuePair<int, float> entry in buf)
            {
                file.WriteLine(entry.Key.ToString() + "\t" + entry.Value.ToString("F2"));
            }
            file.Close();
        }
        catch (System.Exception e)
        {
            Debug.Log("Error in accessing file: " + e);
        }
    }

    public Vector3 world_to_canvas(Vector3 target_pos, Camera camera, Canvas canvas)
	{
		Vector3 screenPos = camera.WorldToViewportPoint(target_pos);
        if (screenPos.z < 0) { screenPos = new Vector3(int.MaxValue, int.MaxValue, 0.0f); }
        else
        {
            screenPos.x *= canvas.GetComponent<RectTransform>().rect.width;
            screenPos.x -= canvas.GetComponent<RectTransform>().rect.width / 2.0f;
            screenPos.y *= canvas.GetComponent<RectTransform>().rect.height;
            screenPos.y -= canvas.GetComponent<RectTransform>().rect.height / 2.0f;
            screenPos.z = 0.0f;
        }

		return screenPos;

	}

    public Vector3 world_to_canvas_LDCorner(Vector3 target_pos, Camera camera)
    {
        Vector3 screenPos = camera.WorldToScreenPoint(target_pos, Camera.MonoOrStereoscopicEye.Mono);
        if (screenPos.z < 0) { screenPos = new Vector3(int.MaxValue, int.MaxValue, 0.0f); }
        else
        {
            screenPos.z = 0.0f;
        }

        return screenPos;

    }
}
