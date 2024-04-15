using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public GameObject foodItemPrefab; // Prefab for the food item
    public float foodOffsetY = 1.0f;
    public float timeToBecomeUnsatisfied = 30f; // Time in seconds for the customer to wait for food
    private float satisfactionTimer;

    public bool isSatisfied = false;
    public bool hasBeenServed = false; 

    private mood customerMood; // Reference to the mood component
    private int currentMoodLevel = 0; //

    void Start()
    {
        customerMood = GetComponent<mood>(); // Get the mood component
        satisfactionTimer = timeToBecomeUnsatisfied;
        customerMood.UpdateMood(0);
        
    }
    void Update()
    {
        if (!isSatisfied && !hasBeenServed)
        {
            satisfactionTimer -= Time.deltaTime;
            
            // Check the timer and update the mood accordingly
            if (satisfactionTimer <= timeToBecomeUnsatisfied / 2 && satisfactionTimer > 0)
            {
                // Update to getting angry sprite
                customerMood.UpdateMood(1);
            }
            else if (satisfactionTimer <= 0)
            {
                // Update to angry sprite
                customerMood.UpdateMood(2);
                satisfactionTimer = timeToBecomeUnsatisfied; // Reset the timer if you want the mood to change repeatedly
            }
        }
    }

    private IEnumerator SpawnCustomerWithFood()
    {
        // Wait a little before starting the routine.
        yield return new WaitForSeconds(2.0f);

        // Find all customer GameObjects in the scene
        GameObject[] customers = GameObject.FindGameObjectsWithTag("Customer");

        foreach (GameObject customer in customers)
        {
            // Instantiate the food item above each customer
            GameObject food = Instantiate(foodItemPrefab, 
                                        customer.transform.position + new Vector3(0, foodOffsetY, 0), 
                                        Quaternion.identity);
            food.transform.localScale = new Vector3(0.4f, 0.4f, 0.2f);
            food.transform.SetParent(customer.transform, false);
        }
    }
}
