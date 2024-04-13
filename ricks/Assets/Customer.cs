using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Customer : MonoBehaviour
{
    public GameObject custPreFab;
    public float fixedY = 1.0f;
    public float minX = -5.0f;
    public float maxX = 5.0f;
    public List<Sprite> menuSpriteList = new List<Sprite>();
    public List<Sprite> custSpriteList = new List<Sprite>();
    public float spawnIntervalMin = 2.0f;
    public float spawnIntervalMax = 7.0f;

    void Start()
    {
        StartCoroutine(SpawnCustomerCoroutine());
    }

    IEnumerator SpawnCustomerCoroutine()
    {
        while (true)
        {
            float waitTime = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(waitTime);
            SpawnCustomer();
        }
    }
    

    void SpawnCustomer()
    {
        GameObject newCust = Instantiate(custPreFab, new Vector2(Random.Range(minX, maxX), fixedY), Quaternion.identity);
        mood custMood = newCust.GetComponent<mood>();

        if (custMood != null)
        {
            custMood.custSpriteList = custSpriteList;
            custMood.menuSpriteList = menuSpriteList;
            custMood.RandomOrder();
        }
    }
}