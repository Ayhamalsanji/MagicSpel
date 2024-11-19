using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Movement speed
    private Rigidbody2D rb;
    private Vector2 movement;

    private bool facingRight = true; // Tracks the player's current facing direction

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is missing!");
        }

        // Lock rotation explicitly
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // Get input for movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Store movement direction
        movement = new Vector2(moveX, moveY).normalized;

        // Handle player turning only when moving horizontally
        if (moveX > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveX < 0 && facingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        // Move the player
        if (movement != Vector2.zero)
        {
            rb.velocity = movement * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero; // Stop the player when there's no input
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        // Flip the player's local scale on the X-axis
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
