using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScptTEST : MonoBehaviour
{
    public GameObject FireBall;           // Reference to the fireball prefab
    public float fireBallSpeed = 10f;     // Speed of the fireball
    public float fireRate = 0.3f;         // Time interval between shots
    private float nextFireTime = 0f;      // When the player can shoot again
    private bool canCast = true;          // Whether the player can cast a fireball
    public Transform spawnPoint;          // The point where the fireball spawns
    private PlayerMovement playerMovement; // Reference to PlayerMovement script

    void Start()
    {
        // Get the PlayerMovement component from the player object
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // Check if the left mouse button is pressed and if we can shoot
        if (Input.GetMouseButtonDown(0) && canCast)  // Left-click (mouse button 0)
        {
            ShootFireBall();  // Shoot the fireball immediately
            canCast = false;  // Disable shooting until fireRate time has passed
            playerMovement.DisableMovement();  // Disable player movement only for this frame
            nextFireTime = Time.time + fireRate;  // Set the next possible fire time
        }

        // Allow shooting again after fireRate time has passed and enable movement
        if (Time.time >= nextFireTime)
        {
            canCast = true;
            playerMovement.EnableMovement(); // Re-enable player movement after shooting cooldown
        }
    }

    // Method to create and shoot the fireball
    void ShootFireBall()
    {
        if (FireBall != null)
        {
            // Instantiate the fireball at the spawnPoint's position and rotation
            GameObject fireballInstance = Instantiate(FireBall, spawnPoint.position, spawnPoint.rotation);

            // Get the Rigidbody2D component of the fireball
            Rigidbody2D rb = fireballInstance.GetComponent<Rigidbody2D>();
            Physics2D.IgnoreCollision(fireballInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            if (rb != null)
            {
                // Get the mouse position in world coordinates
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;  // Make sure z is 0, as we're working in 2D

                // Calculate the direction from the spawnPoint to the mouse position
                Vector2 direction = (mousePosition - spawnPoint.position).normalized;

                // Set the velocity of the fireball in the direction of the mouse
                rb.velocity = direction * fireBallSpeed;
            }
            else
            {
                Debug.LogError("Rigidbody2D missing on Fireball prefab! Please add a Rigidbody2D component.");
            }
        }
        else
        {
            Debug.LogError("Fireball Prefab is missing! Please assign a prefab in the Inspector.");
        }
    }
}







