using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{

    [SerializeField] private Slider HPSlider;
    [SerializeField] private TextMeshProUGUI healthText;
    private int displayedMaxHealth;

    public void SetMaxHealth(int maxHealth)
    {
        displayedMaxHealth = maxHealth;

        HPSlider.maxValue = maxHealth;
        HPSlider.value = maxHealth;

        UpdateHealthText(maxHealth);
    }

    public void SetHealth(int currentHealth)
    {
    HPSlider.value = currentHealth;

    UpdateHealthText(currentHealth);
    }

    
    private void UpdateHealthText(int currentHealth)
    {
        if (healthText != null)
            healthText.text =
                $"HP: {currentHealth} / {displayedMaxHealth}";
    }   
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
