using UnityEngine;
using UnityEngine.SceneManagement;
 using TMPro;

public class GameManager : MonoBehaviour
{   
   
[SerializeField] private GameScore gameScore;
[SerializeField] private TMP_Text finalScoreText;
[SerializeField] private GameObject gameOverPanel;

    private bool isGameOver;

    private void Start()
    {
        if (gameOverPanel != null)     gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        if (isGameOver) return;
        Time.timeScale = 0f;
        
        isGameOver = true;

        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
