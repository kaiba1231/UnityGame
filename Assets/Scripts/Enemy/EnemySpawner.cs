using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    public void SpawnEnemy()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy Prefab is NULL!");
            return;
        }

        Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        Debug.Log("Enemy Spawned!");
    }

    void Start()
    {
    }
}