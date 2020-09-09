using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCreateTest : MonoBehaviour
{
    [SerializeField] private SpriteRenderer SR;
    [SerializeField] private Texture2D Texture;

    // Start is called before the first frame update
    void Start()
    {
        Sprite sprite = Sprite.Create(Texture, new Rect(0.0f, 0.0f, Texture.width, Texture.height), 
            new Vector2(0.5f, 0.5f));
        SR.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
