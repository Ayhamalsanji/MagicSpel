using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthSlider;  // UI Slider to show the player's health
    public GameObject gameOverScreen;  // UI for Game Over (optional)

    void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);  // Hide the Game Over screen at the start
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        Debug.Log("Player took damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player has died!");

        Time.timeScale = 0f;  // Pauses the game

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);  // Show Game Over screen
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        Time.timeScale = 1f;  // Unpause the game when resetting health
    }
}
