using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityClasses
{
    [System.Obsolete]
    [System.Serializable]
    public struct Viewportpos_XY
    {
        public float x;
        public float y;
    };

    /// <summary>
    /// Multiplier for a single tier;
    /// </summary>
    [System.Serializable]
    public struct TierMulti_list
    {
        public int[] Multiplier_list;
    }
}
