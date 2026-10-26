using System.Data;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyAI))]

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; 
    private Rigidbody2D rb; 
    //private Transform playerTransform;
    private EnemyAI enemyAI;
    private float knockbackEndtime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAI = GetComponent<EnemyAI>();
        // GameObject playerObject  = GameObject.FindGameObjectWithTag("Player");

        // if (playerObject != null) 
        // {playerTransform = playerObject.transform;}
    }


    // Update is called once per frame
   private void FixedUpdate()
    {
        if (Time.time < knockbackEndtime) return;

        if (enemyAI.IsPatrolling)
        {
            // Di chuyển tuần tra
            Vector2 patrolTarget = enemyAI.PatrolTarget;

            Vector2 direction = (patrolTarget - rb.position).normalized;
            Vector2 targetPosition = rb.position + direction * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(targetPosition);
        }
        else if (enemyAI.IsChasing)
        {
            // Đuổi theo player
            Transform player = enemyAI.Player;
            if (player == null) return;

            Vector2 direction = ((Vector2)player.position - rb.position).normalized;
            Vector2 targetPosition = rb.position + direction * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(targetPosition);
        }
    }

    public void ApplyKnockbackDelay(float duration)
    {
        knockbackEndtime = Time.time + duration;
    }
}
