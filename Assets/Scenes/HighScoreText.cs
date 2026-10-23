using UnityEngine;
using TMPro;

public class HighScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highscoretext;
    

    void Start()
    {
        int highScore = 0;
        
        if (PersistentGameManager.Instance != null)
        {
           highScore = PersistentGameManager.Instance.HighScore; 
        }

        if (highscoretext != null)
        {
            highscoretext.text = "High Score: " + highScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
