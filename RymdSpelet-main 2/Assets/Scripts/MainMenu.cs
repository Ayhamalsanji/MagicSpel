using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Metod som kallas n�r Start-knappen trycks
    public void StartGame()
    {
        // Ladda n�sta scen (spelet)
        SceneManager.LoadScene("RymdSpelet_Scen2");  // Byt ut "GameScene" till namnet p� din spelscen
    }

    // Metod som kallas n�r Exit-knappen trycks
    public void QuitGame()
    {
        // Avsluta spelet
        Debug.Log("Game is exiting..."); // Detta fungerar bara i editorn
        Application.Quit();  // Detta st�nger spelet n�r det �r kompilerat som ett exekverbart program
    }
}
    