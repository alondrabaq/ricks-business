using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookScript : MonoBehaviour
{
    public Rigidbody2D rigbod;
    public float moveSpeed;
    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();   
    }

    void FixedUpdates()
    {
        Move();
    }

    void ProcessInputs() 
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    } 

    void Move() 
    {
        rigbod.MovePosition(rigbod.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
