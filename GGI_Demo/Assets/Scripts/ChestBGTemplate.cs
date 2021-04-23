using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Template (in editor) of the chest group;
/// </summary>
public class ChestBGTemplate : MonoBehaviour
{
    [SerializeField] private Transform widthD_TRANS;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Get the width relative to the viewport;
    /// </summary>
    /// <returns></returns>
    public float Get_x_viewport()
    {
        return Camera.main.WorldToViewportPoint(widthD_TRANS.position).x;
    }

    /// <summary>
    /// Safely destroy self;
    /// </summary>
    public void Self_destroy()
    {
        Destroy(gameObject);
    }
}
