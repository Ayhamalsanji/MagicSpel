using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float moveSpeed = 2f;  // Speed of the enemy ship
    public int damageAmount = 20; // Damage amount dealt to the player

    void Update()
    {
        // Move the enemy ship downwards
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        // Destroy the enemy ship if it goes off the screen (optional)
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    // Detect collision with the player or laser
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Deal damage to the player
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damageAmount);
            }

            // Destroy the enemy ship
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Laser"))
        {
            // Add 100 points to the score when an enemy is hit by a laser
            ScoreManager.instance.AddScore(100);

            // Destroy the laser and the enemy ship
            Destroy(collision.gameObject);  // Destroy the laser
            Destroy(gameObject);            // Destroy the enemy ship
        }
    }
}
