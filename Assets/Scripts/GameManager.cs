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

        isGameOver = true;

        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        
        if (gameScore != null && finalScoreText != null)
        {
            finalScoreText.SetText( "Final Score: {0:0}", gameScore.Score);
        }

    }

    public void RestartGame()
    {
        SceneManager
            .LoadScene(SceneManager
                .GetActiveScene().buildIndex);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
