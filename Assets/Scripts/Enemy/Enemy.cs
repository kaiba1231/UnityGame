using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private int attackDamage = 20;
    public string enemyType = "Goblin";
    private int maxHP = 50;
    public int currentHP;
    void Start()
    {
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hit: " + collision.gameObject.name);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth enemyHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
                currentHP -= 50;
            }
        }
    }


    // Update is called once per frame
   
}
