using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldToViewportTest : MonoBehaviour
{
    [SerializeField] private Camera Cam;
    [SerializeField] private Transform Target_TRANS;
    [SerializeField] private Text TM;
    [SerializeField] private Canvas Canv;
    [SerializeField] private Transform Convert_TRANS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 pos = Cam.WorldToScreenPoint(Target_TRANS.position, Camera.MonoOrStereoscopicEye.Mono);
        Vector3 pos = world_to_canvas(Target_TRANS.position, Cam, Canv);
        TM.text = pos.ToString("F4");
        Convert_TRANS.GetComponent<RectTransform>().anchoredPosition = pos;

    }

	public static Vector3 world_to_canvas(Vector3 target_pos, Camera camera, Canvas canvas)
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

    public static Vector3 world_to_canvas_LDCorner(Vector3 target_pos, Camera camera)
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
