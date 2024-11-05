using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton s� att vi enkelt kan komma �t po�ngr�knaren fr�n andra skript
    public Text scoreText; // Textobjektet f�r att visa po�ngen
    private int score = 0; // Startpo�ng

    private void Awake()
    {
        // Skapa en singleton f�r att h�lla koll p� po�ngen genom spelet
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
        // Starta med att visa 0 po�ng
        scoreText.text = "Score: " + score;
    }

    // Funktion f�r att l�gga till po�ng n�r fienden besegras
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    // �terst�lla po�ngen till 0 (n�r spelaren d�r)
    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }
}
