using UnityEngine;
using System;

/// <summary>
/// Handler of all inputs;
/// </summary>
public class InputHandler : MonoBehaviour
{
    public static InputHandler IS { get; private set; } //Instance;

    [SerializeField] private bool run_update;
    [SerializeField] private bool track_mouse_position;

    public Vector3 MousePosition { get; set; }
    public Action MouseLeftDown { get; set; }
    public Action MouseLeftUp { get; set; }


    private void Awake()
    {
        IS = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(run_update)
        {
            TDMousePosTracking();
            MouseButtonTracking();
        }
    }

    #region Private methods;

    /// <summary>
    /// 2D Mouse tracking function, call in update;
    /// </summary>
    private void TDMousePosTracking()
    {
        if (!track_mouse_position) { return; }
        MousePosition = Input.mousePosition;
    }

    /// <summary>
    /// Track mouse buttons;
    /// </summary>
    private void MouseButtonTracking()
    {
        if(Input.GetMouseButtonDown(0) && MouseLeftDown != null)
        {
            MouseLeftDown();
        }
        if (Input.GetMouseButtonUp(0) && MouseLeftUp != null)
        {
            MouseLeftUp();
        }
    }

    #endregion
}
