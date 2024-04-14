using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScriptMenu : MonoBehaviour
{
    public Sprite unpushedSprite;
    public Sprite pushedSprite;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = unpushedSprite; // Set initial sprite
    }

    void OnMouseDown() // Changes sprite when mouse clicks the GameObject
    {
        spriteRenderer.sprite = pushedSprite;
    }

    void OnMouseUp() // Reverts sprite when mouse releases the GameObject
    {
        spriteRenderer.sprite = unpushedSprite;
    }
}

