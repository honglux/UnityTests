using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LoadResources : MonoBehaviour
{
    [SerializeField] private SpriteRenderer s_renderer;
    [SerializeField] private TextMesh text;

    Sprite[] sprites;

    private float timer = 2.0f;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.sprites = Resources.LoadAll<Sprite>("123");

        foreach(Sprite temp in sprites)
        {
            Debug.Log("temp " + temp.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = 2.0f;
            index++;
            index %= sprites.Length;
            //s_renderer.sprite = sprites[index];   //Not working;
            //text.text = sprites[index].name;
            Debug.Log("index " + index);
            s_renderer.sprite = sprites.Single(n => n.name == (index+1).ToString());
            text.text = s_renderer.sprite.name;
            
        }
    }
}
