using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using System;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Enemy movement speed for linear chasing
    public float detectionRadius = 30.0f; // Radius to detect the player
    public float dashForce = 10.0f; // Force applied for the dash
    public float dashCooldown = 3.0f; // Cooldown between dashes
    public float dashDuration = 0.2f; // Duration of the dash
    public int damage = 1; // Damage dealt to the player
    public int maxHealth = 10; // Maximum health of the enemy

    private int currentHealth; // Current health of the enemy
    private Transform player; // Reference to the player's transform
    private Rigidbody2D rb; // Enemy's Rigidbody2D component
    private bool isPlayerInRange = false; // Tracks if the player is within detection range
    private bool canDash = true; // Tracks if the enemy can dash
    private bool isDashing = false; // Tracks if the enemy is currently dashing'

    private void Start()
    {
        // Initialize health
        currentHealth = maxHealth;

        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Enemy Rigidbody2D is missing!");
        }
        else
        {
            // Freeze rotation to prevent spinning
            rb.freezeRotation = true; // Equivalent to setting z-axis rotation constraint
        }

        // Find the player in the scene (by tag)
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player GameObject not found in the scene!");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // Check if the player is within detection radius
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            isPlayerInRange = distanceToPlayer <= detectionRadius;

            // Attempt to dash if conditions are met
            if (isPlayerInRange && canDash)
            {
                StartCoroutine(DashTowardPlayer());
            }
        }
    }

    private void FixedUpdate()
    {
        // Handle linear movement when not dashing
        if (isPlayerInRange && !isDashing && player != null)
        {
            ChasePlayer();
        }
        else if (!isPlayerInRange && !isDashing)
        {
            StopMoving();
        }
    }

    private void ChasePlayer()
    {
        // Calculate the direction to the player
        Vector2 direction = (player.position - transform.position).normalized;

        // Move toward the player
        rb.velocity = direction * moveSpeed;
    }

    private void StopMoving()
    {
        // Stop all movement
        rb.velocity = Vector2.zero;
        Debug.Log("dashing");
    }

    private IEnumerator DashTowardPlayer()
    {
        if (isDashing || !canDash) yield break; // Prevent overlapping dashes

        StopMoving();

        canDash = false; // Start dash cooldown
        isDashing = true; // Set dashing flag

        Debug.Log("Enemy is dashing!");

        // Calculate the direction to the player
        Vector2 direction = (player.position - transform.position).normalized;

        // Apply force for the dash
        rb.velocity = direction * dashForce;

        // Wait for the dash duration
        yield return new WaitForSeconds(dashDuration);

        // Stop dashing and resume normal movement
        rb.velocity = Vector2.zero;
        isDashing = false;

        yield return new WaitForSeconds(2);
        ChasePlayer();

        Debug.Log("Dash complete.");

        // Start dash cooldown
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

        Debug.Log("Dash cooldown ended. Enemy can dash again.");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the PlayerHealth component
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                Debug.Log($"Enemy dealt {damage} damage to player.");
                playerHealth.TakeDamage(damage);
            }
        }
        if (collision.gameObject.CompareTag("Fireball"))
        {
            // Take damage from fireball
            TakeDamage(1);

            // Destroy the fireball on collision
            Debug.Log("Enemy hit by fireball. Destroying fireball.");
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"Enemy took {amount} damage. Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy has died.");
        // Perform any death-related actions here (e.g., play animation, drop loot, notify game manager)
        Destroy(gameObject); // Destroy the enemy GameObject
    }

    private void OnDrawGizmosSelected()
    {
        // Draw the detection radius in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
