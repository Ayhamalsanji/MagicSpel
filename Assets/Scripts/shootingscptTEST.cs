using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScptTEST : MonoBehaviour
{
    public GameObject FireBall;           // Reference to the fireball prefab
    public float fireBallSpeed = 10f;     // Speed of the fireball
    public float fireRate = 0.3f;         // Time interval between shots
    private float nextFireTime = 0f;      // Next allowed shooting time
    private bool canCast = true;          // If the player can shoot

    void Update()
    {
        // Check for shooting input and whether the player can shoot
        if (Input.GetMouseButtonDown(0) && canCast) // Left mouse button
        {
            ShootFireBall();
            canCast = false; // Prevent immediate re-shooting
            nextFireTime = Time.time + fireRate; // Set the cooldown for the next shot
        }

        // Reset shooting ability when cooldown is over
        if (Time.time >= nextFireTime)
        {
            canCast = true;
        }
    }

    void ShootFireBall()
    {
        if (FireBall != null)
        {
            // Get mouse position in world coordinates
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Ensure the z-position is set to 0 for 2D

            // Calculate the direction from the player to the mouse pointer
            Vector2 shootDirection = (mousePosition - transform.position).normalized;

            // Determine the fireball's spawn position (slightly offset in the shooting direction)
            Vector3 spawnPosition = transform.position + (Vector3)shootDirection * 0.5f;

            // Calculate the rotation of the fireball to face the direction of shooting
            float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
            Quaternion fireballRotation = Quaternion.Euler(0, 0, angle);

            // Instantiate the fireball
            GameObject fireballInstance = Instantiate(FireBall, spawnPosition, fireballRotation);

            // Ignore collision between the fireball and the player
            Collider2D fireballCollider = fireballInstance.GetComponent<Collider2D>();
            Collider2D playerCollider = GetComponent<Collider2D>();
            if (fireballCollider != null && playerCollider != null)
            {
                Physics2D.IgnoreCollision(fireballCollider, playerCollider);
            }

            // Set the fireball's velocity
            Rigidbody2D rb = fireballInstance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = shootDirection * fireBallSpeed;
            }

            // Destroy the fireball after 0.5 seconds
            Destroy(fireballInstance, 0.5f);
        }
        else
        {
            Debug.LogError("Fireball Prefab is missing! Assign a prefab in the Inspector.");
        }
    }
}
