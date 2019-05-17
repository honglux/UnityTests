using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentTest : MonoBehaviour
{
    private Transform cache;
    // Start is called before the first frame update
    void Start()
    {
        cache = transform;
        while (cache != null)
        {
            Debug.Log("cache " + cache.name);
            cache = cache.parent;
            Debug.Log("null " + (cache == null));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
