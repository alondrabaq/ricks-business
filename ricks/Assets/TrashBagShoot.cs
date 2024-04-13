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
        // Shoot the trash bag when the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space) && !shot)
        {
            rb.AddForce(Vector2.up * shootForce);
            shot = true; // Prevent further shots
        }
    }
}
