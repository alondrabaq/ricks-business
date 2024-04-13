using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBagShoot : MonoBehaviour
{
    public float shootForce = 500f; // The force applied when shooting
    private Rigidbody2D rb;
    private bool shot = false; // To prevent shooting multiple times
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Shoot the trash bag when the space bar is pressed and the shot is not active
        if (Input.GetKeyDown(KeyCode.Space) && !shot)
        {
            rb.AddForce(Vector2.up * shootForce);
            shot = true; // Prevent further shots
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object it collided with is the floor
        if (shot && rb.velocity.magnitude < 0.01f)
        {
            ResetShot(); // Reset the shot so it can shoot again
        }
    }

    // Call this method to reset the shot flag
    public void ResetShot()
    {
        shot = false;
        // Optionally, also reset the position and velocity of the trash bag
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = new Vector2(0, -3.95f); // Use the initial position of the trash bag
    }
}
