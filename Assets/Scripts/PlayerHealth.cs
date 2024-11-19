using UnityEngine;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
    public GameObject HeartCounter;

    public static event System.Action OnPlayerDamaged;
    public static event System.Action OnPlayerDeath;

    public int health, maxHealth;

    private bool canTakeDamage = true; // Cooldown flag
    public float damageCooldown = 1.0f; // Cooldown duration in seconds

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        // Check if the player can take damage
        if (!canTakeDamage)
        {
            Debug.Log("Player is still in cooldown. Damage ignored.");
            return;
        }

        // Reduce health
        health -= amount;

        // Clamp health to prevent negative values
        health = Mathf.Clamp(health, 0, maxHealth);

        // Update UI
        HeartCounter.GetComponent<heartHealthBar2>().UpdateHealth(health);

        // Trigger damage event
        OnPlayerDamaged?.Invoke();

        Debug.Log($"Player took {amount} damage. Current health: {health}/{maxHealth}");

        // Check for death
        if (health <= 0)
        {
            Debug.Log("Player is dead.");
            OnPlayerDeath?.Invoke();
        }

        // Start cooldown
        StartCoroutine(DamageCooldown());
    }

    private IEnumerator DamageCooldown()
    {
        canTakeDamage = false; // Disable further damage
        Debug.Log("Damage cooldown started.");
        yield return new WaitForSeconds(damageCooldown); // Wait for cooldown duration
        canTakeDamage = true; // Re-enable damage
        Debug.Log("Damage cooldown ended.");
    }
}
