using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;          // Maximum health the player can have
    private int currentHealth;           // Current health of the player

    public Slider healthSlider;          // UI Slider to show the player's health
    public Text gameOverText;            // UI Text for the Game Over message

    void Start()
    {
        // Initialize player's health at the start
        currentHealth = maxHealth;
        UpdateHealthUI();  // Update health UI to show the current health

        // Ensure the Game Over text is hidden at the start
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false); // Hide Game Over text initially
        }
    }

    // Method to handle taking damage
    public void TakeDamage(int damage)
    {
        Debug.Log("Player is taking damage: " + damage); // For debugging purposes

        currentHealth -= damage;  // Reduce the player's health by the damage value
        UpdateHealthUI();         // Update health UI after taking damage

        // Check if the player's health is 0 or below
        if (currentHealth <= 0)
        {
            Die();  // Call Die() method if health reaches 0
        }
    }

    // Method to update the health slider UI
    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;  // Update the slider with current health
        }
    }

    // Method to handle the player's death
    void Die()
    {
        Debug.Log("Player has died!");

        // Display Game Over text
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);  // Show the Game Over text
        }

        // Optional: pause the game when the player dies
        Time.timeScale = 0;  // Pauses the game
    }

    // Optional: Method to reset player health (can be called when restarting the game)
    public void ResetHealth()
    {
        currentHealth = maxHealth;  // Reset health to the maximum value
        UpdateHealthUI();           // Update health UI after resetting
        Time.timeScale = 1;         // Unpause the game
    }
}
