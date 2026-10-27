using UnityEngine;

public enum EnemyState { Idle, Patrol, Chase, Attack }


public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float chaseRange = 6f;
    [SerializeField] private float attackRange = 1.5f;

    [Header("Patrol")]
    [SerializeField] private Vector2 patrolPointA;
    [SerializeField] private Vector2 patrolPointB;
    [SerializeField] private float patrolReachDistance = 0.2f;

    private EnemyState currentState = EnemyState.Idle;
    private EnemyCombat enemyCombat;
    private Vector2 currentPatrolTarget;
    private bool hasPatrolPoints;

    public bool IsChasing => currentState == EnemyState.Chase;
    public bool IsPatrolling => currentState == EnemyState.Patrol;
    public Transform Player => player;
    public Vector2 PatrolTarget => currentPatrolTarget;

    private void Awake()
    {
        enemyCombat = GetComponent<EnemyCombat>();
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }

        // Bắt đầu tuần tra nếu patrol points khác nhau
        hasPatrolPoints = (patrolPointA != patrolPointB);
        if (hasPatrolPoints)
        {
            currentPatrolTarget = patrolPointA;
            currentState = EnemyState.Patrol;
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState == newState) return;
        currentState = newState;
        Debug.Log(gameObject.name + " State: " + currentState);
    }

    private void UpdateState()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        
        if (distance > chaseRange)
        {
            // Player ngoài tầm → quay lại tuần tra (hoặc Idle nếu không có patrol points)
            if (hasPatrolPoints)
                ChangeState(EnemyState.Patrol);
            else
                ChangeState(EnemyState.Idle);
        }
        else if (distance <= attackRange)
        {
            ChangeState(EnemyState.Attack);
        }
        else
        {
            ChangeState(EnemyState.Chase);
        }
    }

    private void Update() 
    {
        if (player == null)
        {
            ChangeState(EnemyState.Idle);
            return;
        }
        UpdateState();

        switch (currentState)
        {
            case EnemyState.Idle:
                HandleIdle();
                break;
            case EnemyState.Patrol:
                HandlePatrol();
                break;
            case EnemyState.Chase:
                HandleChase();
                break;
            case EnemyState.Attack:
                HandleAttack();
                break;  
        }
    }

    private void HandleIdle()
    {
        // Idle: enemy đứng yên, không di chuyển
    }

    private void HandlePatrol()
    {
        // Đến gần patrol point → đổi hướng
        float distToTarget = Vector2.Distance(transform.position, currentPatrolTarget);
        if (distToTarget <= patrolReachDistance)
        {
            // Nếu đang đi tới A thì chuyển sang B, ngược lại chuyển về A
            if (currentPatrolTarget == patrolPointA)
            {
                currentPatrolTarget = patrolPointB;
            }
            else
            {
                currentPatrolTarget = patrolPointA;
            }
        }
    }

    private void HandleChase()
    {
        // Chase: di chuyển được xử lý bởi EnemyMovement
    }

    private void HandleAttack()
    {
        if (enemyCombat != null)
        {
            enemyCombat.TryAttack(player);
        }
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.yellow;
        UnityEditor.Handles.DrawWireDisc(transform.position,Vector3.forward,chaseRange);

        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(transform.position,Vector3.forward,attackRange);
        
        Gizmos.color = Color.green;

        Gizmos.DrawLine(patrolPointA, patrolPointB);

        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawWireDisc(patrolPointA, Vector3.forward, patrolReachDistance);

        UnityEditor.Handles.DrawWireDisc(patrolPointB, Vector3.forward, patrolReachDistance);
    }
#endif
}
