using UnityEditor.Rendering;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{   
    [SerializeField] private int maxHP = 100;
 
    [SerializeField] private HealthBarUI healthBarUI;
    [SerializeField] private GameManager gameManager;


    int currentHP;
    private void Awake()
    {
        currentHP = maxHP;
    }

    private void Die()
    {   
        Debug.Log("Nhan vat die");
        if (gameManager != null)    gameManager.GameOver();
        gameObject.SetActive(false);
    }
    
    public void TakeDamage(int damage)
    {
        if (damage <= 0 || currentHP == 0)    return;
        currentHP = Mathf.Max(currentHP - damage, 0);

        // Debug.Log("Player Health: " + currentHealth);
        if (healthBarUI != null)  healthBarUI.SetHealth(currentHP);
        if (currentHP == 0) Die();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Heal(int amount)
    {   
      
        if (amount <= 0)
        {
        return;
        }
        Debug.Log("Hoi mau"+ amount);
        currentHP = Mathf.Min(currentHP + amount, maxHP);

        if (healthBarUI != null)
        {
        healthBarUI.SetHealth(currentHP);
        }
    }

   


    void Start()
    {   
        if (healthBarUI != null)    healthBarUI.SetMaxHealth(maxHP);

    }
}
