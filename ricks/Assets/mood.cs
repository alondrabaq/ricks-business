
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mood : MonoBehaviour
{
    public List<Sprite> custSpriteList = new List<Sprite>();
    public List<Sprite> menuSpriteList = new List<Sprite>();
    public Sprite notAngrySprite;
    public Sprite gettingAngrySprite;
    public Sprite angrySprite;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void RandomOrder()
    {
        Sprite currCust = GetRandomSprite(custSpriteList);
        Sprite currFood = GetRandomSprite(menuSpriteList);
        spriteRenderer.sprite = currCust;
    }

    private Sprite GetRandomSprite(List<Sprite> spriteList)
    {
        if (spriteList != null && spriteList.Count > 0)
        {
            int randomIndex = Random.Range(0, spriteList.Count);
            return spriteList[randomIndex];
        }
        return null;
    }

    public void UpdateMood(int moodLevel)
    {
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
        }
    }
}