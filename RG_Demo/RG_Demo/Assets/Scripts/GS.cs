using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Settings of the game;
/// </summary>
public class GS : MonoBehaviour
{
    public static GS IS { get; private set; }

    public GameObject ArrowSettings_Prefab;

    private void Awake()
    {
        IS = this;
    }
}
