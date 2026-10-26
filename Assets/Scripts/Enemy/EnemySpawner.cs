using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    
    public void SpawnEnemyImmediately()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        
        if (enemy.TryGetComponent<EnemyHealth>(out var enemyHealth))
        {
        enemyHealth.SetSpawner(this);
        }
    }

    void Start()
    {
        SpawnEnemy();
    }
    
    private IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(5);
        SpawnEnemyImmediately();
    }

    public void SpawnEnemy()
    {
        StartCoroutine(DelaySpawn());
    }
}