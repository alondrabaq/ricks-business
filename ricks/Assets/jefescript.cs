using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jefescript : MonoBehaviour
{
    public GameObject money; // Prefab for the money
    public float moneyOffsetY = 1.0f;
    public Sprite walking1;
    public Sprite walking2;
    private SpriteRenderer spriteRenderer;
    private bool isWalking = false;
    public float walkSpeed = 2.0f;
    public Transform startPoint;
    public Transform endPoint;

    void Start()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (money == null)
        {
            Debug.LogError("Money prefab has not been assigned in the inspector.");
            return;
        }

        StartCoroutine(SpawnJefeWithMoney());
        StartWalking();
    }
    private void Update()
    {
       if (isWalking)
        {
            // Get the camera's center in world space
            Vector3 midpoint = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, Camera.main.nearClipPlane));
            
            // Move the character horizontally to the midpoint
            Vector3 targetPosition = new Vector3(midpoint.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, walkSpeed * Time.deltaTime);
            
            // Stop the character if it reaches the horizontal midpoint of the screen
            if (Mathf.Abs(transform.position.x - midpoint.x-0.2f) < 0.1f) // 0.1f is a small threshold to allow for float imprecision
            {
                isWalking = false;
                // Reset the sprite or perform any action needed when the character stops walking
                spriteRenderer.sprite = walking1; // Replace with your idle sprite if different
            }
        }
    }

    
    public void StartWalking()
    {
        isWalking = true;
    }

    // Call this function to stop walking
    public void StopWalking()
    {
        isWalking = false;
        // Optionally, reset to a default sprite
        spriteRenderer.sprite = walking1;
    }
    private IEnumerator Walking()
    {
        while (true) // Loop indefinitely
        {
            if (isWalking)
            {
                // Toggle between walking sprites
                spriteRenderer.sprite = spriteRenderer.sprite == walking1 ? walking2 : walking1;

                // Move the character forward
                transform.position += transform.right * walkSpeed * Time.deltaTime;
            }
            yield return new WaitForSeconds(0.5f); // Wait half a second between sprite changes
        }
    }

    private IEnumerator SpawnJefeWithMoney()
    {
        while (true) // This will continuously spawn money for the jefe.
        {
            yield return new WaitForSeconds(Random.Range(2.0f, 5.0f)); // Wait for a random time before spawning the next money.

            // Find the jefe GameObject in the scene
            GameObject jefe = GameObject.FindGameObjectWithTag("Jefe");
            if (jefe == null)
            {
                Debug.LogError("Jefe GameObject not found in the scene.");
                yield break;
            }

            // Instantiate the money above the jefe
            GameObject spawnedMoney = Instantiate(money, jefe.transform.position + new Vector3(0, moneyOffsetY, 0), Quaternion.identity);
            spawnedMoney.transform.localScale = new Vector3(0.4f, 0.4f, 0.2f);
            spawnedMoney.transform.SetParent(jefe.transform, false);
        }
    }
}
