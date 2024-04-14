
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mood : MonoBehaviour
{
    public Sprite notAngrySprite;
    public Sprite gettingAngrySprite;
    public Sprite angrySprite;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateMood(0); // Start with not angry sprite
    }

    public void UpdateMood(int moodLevel)
    {
        // Update the sprite based on the mood level
        switch (moodLevel)
        {
            case 0:
                spriteRenderer.sprite = notAngrySprite;
                break;
            case 1:
                spriteRenderer.sprite = gettingAngrySprite;
                break;
            case 2:
                spriteRenderer.sprite = angrySprite;
                break;
            default:
                spriteRenderer.sprite = notAngrySprite; // Default to not angry if an undefined mood level is passed
                break;
        }
    }
}