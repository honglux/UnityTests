using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to handle the mouse raycast;
/// </summary>
public class MouseRayCast : MonoBehaviour
{
    public static MouseRayCast IS;

    [SerializeField] private float distant;
    [SerializeField] private LayerMask layer_mask;

    public bool Casting { get; private set; }
    public bool hit_flag { get; private set; }
    
    private RaycastHit hit_info;

    private void Awake()
    {
        IS = this;

        Casting = false;
        hit_flag = false;
        hit_info = new RaycastHit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Casting)
        {
            cast_mouse_ray();
        }
    }

    private void cast_mouse_ray()
    {
        Ray mouse_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit_flag = Physics.Raycast(mouse_ray, out hit_info, distant, layer_mask);
    }

    public RaycastHit Get_hitinfo()
    {
        return hit_info;
    }

    public void Toggle_casting(bool _casting)
    {
        Casting = _casting;
    }
}
