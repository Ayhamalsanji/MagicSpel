using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton så att vi enkelt kan komma åt poängräknaren från andra skript
    public Text scoreText; // Textobjektet för att visa poängen
    private int score = 0; // Startpoäng

    private void Awake()
    {
        // Skapa en singleton för att hålla koll på poängen genom spelet
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Starta med att visa 0 poäng
        scoreText.text = "Score: " + score;
    }

    // Funktion för att lägga till poäng när fienden besegras
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    // Återställa poängen till 0 (när spelaren dör)
    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }
}
