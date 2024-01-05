using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_btn_sptire : MonoBehaviour
{
    public Sprite newSprite;
    private SpriteRenderer spriteRenderer;
    public void Change_Sprite()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;
    }
}
