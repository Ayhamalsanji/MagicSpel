using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI; // Assign your Game Over UI Canvas here in the Inspector

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += HandleGameOver;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= HandleGameOver;
    }

    private void Start()
    {
        // Ensure Game Over UI is hidden and the game starts running
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
        else
        {
            Debug.LogError("Game Over UI is not assigned in the GameManager!");
        }

        // Ensure the game runs normally at the start
        Time.timeScale = 1;
    }

    private void HandleGameOver()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); // Show Game Over UI
        }

        // Freeze the game
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        // Reset the time scale
        Time.timeScale = 1;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMainMenu()
    {
        // Reset the time scale
        Time.timeScale = 1;

        // Load the Main Menu scene (replace "MainMenu" with your scene name)
        SceneManager.LoadScene("MainMenu");
    }
}
