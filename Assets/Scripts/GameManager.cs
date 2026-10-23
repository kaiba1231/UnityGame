using UnityEngine;
using UnityEngine.SceneManagement;
 using TMPro;

public class GameManager : MonoBehaviour
{   
   
[SerializeField] private GameScore gameScore;
[SerializeField] private GameObject pausePanel;
[SerializeField] private TMP_Text finalScoreText;
[SerializeField] private GameObject gameOverPanel;

    private bool isGameOver;
    private bool isPaused;
    private void Start()
    {   
        Time.timeScale = 1f;
        isGameOver = false;
        isPaused = false;
        if (gameOverPanel != null)     gameOverPanel.SetActive(false);
        if (pausePanel != null) pausePanel.SetActive(false);
    }

    public void PauseGame()
    {
        if (isGameOver || isPaused) return;

        isPaused = true;
        
        Time.timeScale = 0f;

        if (pausePanel != null) pausePanel.SetActive(true);
        
    }
    public void ResumeGame()
    {
        if (isGameOver || !isPaused) return;

        isPaused = false;
        Time.timeScale = 1f;

        if (pausePanel != null) pausePanel.SetActive(false);
    }


    public void GameOver()
    {   
        if (isGameOver) return;
        Time.timeScale = 0f;
        isGameOver = true;
        isPaused = false;


        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        if (pausePanel != null) pausePanel.SetActive(false);
      
        if (gameScore != null && finalScoreText != null)
        {
            finalScoreText.SetText( "Final Score: {0:0}", gameScore.Score);
        }

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager
            .LoadScene(SceneManager
                .GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }
    private void Update()
    {
        if (isGameOver) return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
     
    }
}

