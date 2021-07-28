using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowComponent : MonoBehaviour
{
    [SerializeField] private Image render_image;

    public void UpdateSprite(Sprite sprite)
    {
        render_image.sprite = sprite;
    }

    public void TurnOnSprite()
    {
        render_image.enabled = true;
    }

    public void TurnOffSprite()
    {
        render_image.enabled = false;
    }
}
