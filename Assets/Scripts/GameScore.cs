using UnityEngine;

public class GameScore : MonoBehaviour
{
[SerializeField]
private ScoreUI scoreUI;

private int score;

    public int Score
    {
        get
        {
        return score;
        }
    }

    private void Start()
    {
        if (GameSession.Instance != null)
            {
            score = GameSession.Instance.Score;
            }
        UpdateUI();
    }

    public void AddScore(int amount)
    {   
        if (GameSession.Instance != null)
        {
        GameSession.Instance.Score = score;
        }

        if (amount <= 0)
        {
        return;
        }

        score += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreUI != null) scoreUI.SetScore(score);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
        AddScore(10);
        }
    }
}