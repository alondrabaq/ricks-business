using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private static Random random = new Random();
    public GameObject custPreFab;

    public float fixedY = 1.0f;
    public float minX = -5.0f;
    public float maxX = 5.0f;

    public List<Sprite> menuSpriteList = new List<Sprite>();
    public List<Sprite> custSpriteList = new List<Sprite>();

    public Sprite currCust;
    public Sprite currFood; 
    public float moodThreshold;

    public float angstTIme = 7.0f;
    public float angerTime = 13.0f;
    public float karenTime = 20.0f;

    public Sprite angst;
    public Sprite angry;
    public Sprite karen;


    void Start()
    {
        StartCoroutine(scCoroutine());
    }
    IEnumerator scCouroutine()
    {
        while(true)
        {
            float randInt = random.range(2.0f,7.0f);
            yield return new WaitForSeconds(randInt);
            spawnCust();
        }
    }

    void spawnCust()
    {
        GameObject newCust = Instantiate(custPreFab);

        float randX = random.range(minX,maxX);
        newCust.transform.position = new Vector2(randX, fixedY);

        Customer custScript = newCust.GetComponent<Customer>();

        custScript.custSpriteList = custSpriteList;
        custScript.menuSpriteList = menuSpriteList;

        custScript.moodThreshold = 0.0f;

        custScript.RandomOrder();
    }

    void RandomOrder()
    {
        currCust = GetRandomSprite(custSpriteList);
        currFood = GetRandomSprite(menuSpriteList);

        // Optionally, display the order (e.g., by setting the sprite in a SpriteRenderer component)
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = currentCustomerSprite;

    }
    // Start is called before the first frame update
        Sprite GetRandomSprite(List<Sprite> spriteList)
    {
        if (spriteList != null && spriteList.Count > 0)
        {
            // Generate a random index and return the sprite
            int randomIndex = Random.Range(0, spriteList.Count);
            return spriteList[randomIndex];
        }
        else
        {
            return null;
        }
    }

    // Update is called once per frame
        void Update()
    {
        // Increment the wait time by the time elapsed in the current frame
        waitTime += Time.deltaTime;

        // Check the wait time against the time intervals
        if (waitTime >= karenTime)
        {
            // Change the customer's mood to final angry state
            ChangeCustomerToFinalAngry();
        }
        else if (waitTime >= angerTime)
        {
            // Change the customer's mood to angry
            ChangeCustomerToAngry();
        }
        else if (waitTime >= angstTime)
        {
            // Change the customer's mood to angsty
            ChangeCustomerToAngsty();
        }
    }

    // Method to change the customer's sprite to the angsty sprite
    void ChangeCustomerToAngsty()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = angsty;

        // Optionally, add any additional logic for when the customer becomes angsty
    }

    // Method to change the customer's sprite to the angry sprite
    void ChangeCustomerToAngry()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = angry;

        // Optionally, add any additional logic for when the customer becomes angry
    }

    // Method to change the customer's sprite to the final angry state sprite
    void ChangeCustomerToKaren()
    {
        // Assuming the angry sprite remains the same for final anger, or you can add a different one
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = karen;

        // Optionally, add any additional logic for when the customer reaches final angry state
    }

}
