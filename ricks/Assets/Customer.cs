using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public GameObject foodItemPrefab; // Prefab for the food item
    public float foodOffsetY = 1.0f;

    void Start()
    {
        if (foodItemPrefab == null)
        {
            Debug.LogError("Food item prefab has not been assigned in the inspector.");
            return;
        }

        StartCoroutine(SpawnCustomerWithFood());
    }


    private IEnumerator SpawnCustomerWithFood()
    {
        while (true) // This will continuously spawn food items for the customer.
        {
            yield return new WaitForSeconds(Random.Range(2.0f, 5.0f)); // Wait for a random time before spawning the next food item.

            // Find the customer GameObject in the scene
            GameObject customer = GameObject.FindGameObjectWithTag("Customer");
            if (customer == null)
            {
                Debug.LogError("Customer GameObject not found in the scene.");
                yield break;
            }

            // Instantiate the food item above the customer
            GameObject food = Instantiate(foodItemPrefab, customer.transform.position + new Vector3(0, foodOffsetY, 0), Quaternion.identity);
            food.transform.localScale = new Vector3(0.4f, 0.4f, 0.2f);
            food.transform.SetParent(customer.transform, false);
        }
    }
}
