using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private float knockbackForce = 5f; 
    [SerializeField] private int maxHP = 50; 
    [SerializeField] private float knockbackDuration = 0.2f; 
     [SerializeField] private int scoreReward = 500; 
    [SerializeField] private GameScore gameScore;
   
    private EnemyMovement enemyMovement;
    private Rigidbody2D rb;
    private int currentHP; 
    private EnemySpawner enemySpawner;
    private void Awake()
    {
        currentHP = maxHP;

        //enemySpawner = FindAnyObjectByType<EnemySpawner>();

        rb = GetComponent<Rigidbody2D>();
        if (gameScore == null) gameScore = FindAnyObjectByType<GameScore>();

        if (enemySpawner == null)
        {
            Debug.LogError("KHONG TIM THAY EnemySpawner!", this);
        }
        else
        {
            Debug.Log("DA TIM THAY EnemySpawner: " + enemySpawner.name);
        }
        enemyMovement = GetComponent<EnemyMovement>();
    }

    public void SetSpawner(EnemySpawner spawner)
    {
    enemySpawner = spawner;
    }
    public void TakeDamage(int damage, Vector2 attackerPosition)
    {
        if (damage <= 0) return;
         ApplyKnockback(attackerPosition);
        currentHP = Mathf.Max(currentHP - damage, 0);
        Debug.Log("Enemy HP:" + currentHP);

        if (currentHP == 0) Die();
   
    }

    private void ApplyKnockback(Vector2 attackerPosition)
    {
        if (rb == null) return; 

        Vector2 direction = (rb.position - attackerPosition).normalized;
       

            Debug.Log("Direction: " + direction);
            Debug.Log("Force: " + knockbackForce);
            Debug.Log("Body Type: " + rb.bodyType);
            Debug.Log("Constraints: " + rb.constraints);

        if (enemyMovement != null) 
        {
            enemyMovement.ApplyKnockbackDelay(knockbackDuration);
        }

        rb.linearVelocity = Vector2.zero;

        rb.AddForce (direction * knockbackForce, ForceMode2D.Impulse);
    }
    
   private void Die()
    {
        if (gameScore != null) gameScore.AddScore(scoreReward);

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
    
    }
}
