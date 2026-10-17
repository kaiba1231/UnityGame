using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private int attackDamage = 35;
    [SerializeField] private LayerMask enemyLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void Attack()
    {   
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position,
                                                        attackRange,
                                                        enemyLayer);
        
        foreach (Collider2D hit in hits)
        {   
            EnemyHealth enemyHealth = hit.GetComponent<EnemyHealth> ();

            if (enemyHealth != null) enemyHealth.TakeDamage(attackDamage, transform.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (attackPoint.position,attackRange);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space))
        {
        Attack();
        }
    }
}
