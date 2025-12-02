using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   //19. When the player presses the start button, the system shall show the HUD for Health/XP/Level


   private float maxHealth = 100;
   private float currHealth;
   [SerializeField] private Image healthBarFill;
   private PlayerStats playerStats;
    void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
        if (playerStats != null)
        {
            SetHealth(playerStats.GetHealth());
            maxHealth = playerStats.GetHealth();
        }
    }


    public void UpdateHealth(float amount)
    {
        currHealth += amount;
        UpdateHealthBar();
    }

    public void SetHealth(float newHealth)
    {
        currHealth = newHealth;
        UpdateHealthBar();
    }
   
    private void UpdateHealthBar()
    {
        float optimalFillAmount = currHealth / maxHealth;
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = optimalFillAmount;
        }
    }
}
