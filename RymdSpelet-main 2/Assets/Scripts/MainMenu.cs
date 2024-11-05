using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Metod som kallas när Start-knappen trycks
    public void StartGame()
    {
        // Ladda nästa scen (spelet)
        SceneManager.LoadScene("RymdSpelet_Scen2");  // Byt ut "GameScene" till namnet på din spelscen
    }

    // Metod som kallas när Exit-knappen trycks
    public void QuitGame()
    {
        // Avsluta spelet
        Debug.Log("Game is exiting..."); // Detta fungerar bara i editorn
        Application.Quit();  // Detta stänger spelet när det är kompilerat som ett exekverbart program
    }
}
    