using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

    public int glotesst1 { get; set; }

    private void Awake()
    {
        DontDestroyOnLoad(this);

        this.glotesst1 = 200;
    }
}
