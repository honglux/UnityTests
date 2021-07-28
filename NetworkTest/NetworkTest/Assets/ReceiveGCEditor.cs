using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveGCEditor : ReceiveGC
{

    [SerializeField] private TextMesh r_text;

    private void Update()
    {
        update_text(message);
    }

    private void update_text(string message)
    {
        r_text.text = message;
    }
}
