using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    public GameObject gameOverUI;

    private bool isGameOver = false;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensures only one instance exists
            return;
        }
    }
    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Time.timeScale = 0f; // Pause the game
            gameOverUI.SetActive(true);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        isGameOver = false; // Reset game over state
        gameOverUI.SetActive(false); // Hide game over UI
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f; // Resume the game
        isGameOver = false; // Reset game over state
        gameOverUI.SetActive(false); // Hide game over UI
        SceneManager.LoadScene("MainMenu");
    }
}