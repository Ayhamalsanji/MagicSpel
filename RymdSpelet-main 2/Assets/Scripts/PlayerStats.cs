using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public void Die()
    {
        // Lägg till logik för vad som händer när spelaren dör
        Debug.Log("Player has died!");

        // Återställ poängen när spelaren dör
        ScoreManager.instance.ResetScore();
    }

// Variabler för spelarens hälsa och extra liv
public int health = 100;    // Spelarens hälsa

    void Start()
    {
        // Här kan du initiera logik om du vill, t.ex. printa startvärden
        Debug.Log("Player Health: " + health);
    }

    // Du kan lägga till logik för att hantera hälsa och extra liv senare
}
