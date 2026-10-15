using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{


    [SerializeField] private int maxHP = 50; 
    private int currentHP; 
    private EnemySpawner enemySpawner;
    private void Awake()
    {
        currentHP = maxHP;

        enemySpawner = FindAnyObjectByType<EnemySpawner>();

        if (enemySpawner == null)
        {
            Debug.LogError("KHONG TIM THAY EnemySpawner!", this);
        }
        else
        {
            Debug.Log("DA TIM THAY EnemySpawner: " + enemySpawner.name);
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0) return;

        currentHP = Mathf.Max(currentHP - damage, 0);
        Debug.Log("Enemy HP:" + currentHP);

        if (currentHP == 0) Die();
    }

    
   private void Die()
    {
        Debug.Log("Enemy die");

        if (enemySpawner != null)
        {
            Debug.Log("Calling SpawnEnemy()");
            enemySpawner.SpawnEnemy();
        }
        else
        {
            Debug.LogError("EnemySpawner is NULL!");
        }

        Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
        TakeDamage (25);
        }
    }
}
