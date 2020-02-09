using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCGC : MonoBehaviour
{
    [SerializeField] private Camera camera1;
    [SerializeField] private Camera camera2;
    [SerializeField] private GameObject acuity_OBJ;
    [SerializeField] private GameObject target_OBJ;
    [SerializeField] private Canvas canvas1;

    // Start is called before the first frame update
    void Start()
    {
        if(Display.displays.Length == 2)
        {
            Display.displays[1].Activate();
        }

        camera1.transform.eulerAngles = new Vector3(0.0f, 318.0f, 0.0f);
        //Vector3 screenPos = camera1.WorldToViewportPoint(target_OBJ.transform.position);
        //screenPos.x *= canvas1.GetComponent<RectTransform>().rect.width;
        //screenPos.x -= canvas1.GetComponent<RectTransform>().rect.width / 2.0f;
        //screenPos.y *= canvas1.GetComponent<RectTransform>().rect.height;
        //screenPos.y -= canvas1.GetComponent<RectTransform>().rect.height / 2.0f;
        //screenPos.z = 0.0f;
        //Debug.Log("pos "+ screenPos.ToString("F2"));
        //acuity_OBJ.GetComponent<RectTransform>().localPosition = screenPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
