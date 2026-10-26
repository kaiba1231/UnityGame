using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "SceneLevel2";
    private bool isLoading;

    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (!collision.CompareTag("Player")) return;
    if (isLoading) return;
    isLoading = true;

    Time.timeScale = 1f;
    SceneManager.LoadScene(nextSceneName);
    }
}