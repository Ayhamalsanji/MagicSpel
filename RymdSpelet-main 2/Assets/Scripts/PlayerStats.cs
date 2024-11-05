using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public void Die()
    {
        // L�gg till logik f�r vad som h�nder n�r spelaren d�r
        Debug.Log("Player has died!");

        // �terst�ll po�ngen n�r spelaren d�r
        ScoreManager.instance.ResetScore();
    }

// Variabler f�r spelarens h�lsa och extra liv
public int health = 100;    // Spelarens h�lsa

    void Start()
    {
        // H�r kan du initiera logik om du vill, t.ex. printa startv�rden
        Debug.Log("Player Health: " + health);
    }

    // Du kan l�gga till logik f�r att hantera h�lsa och extra liv senare
}
