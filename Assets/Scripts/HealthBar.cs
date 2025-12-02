using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   //19. When the player presses the start button, the system shall show the HUD for Health/XP/Level


   private float maxHealth = 100; // Maximum health of player
   private float currHealth;
   [SerializeField] private Image healthBarFill; 
   private PlayerStats playerStats; // Connects HealthBar to PlayerStats.cs
    void Start() // Enables player's original health stats 
    {
        playerStats = FindFirstObjectByType<PlayerStats>(); // Obtains player stats (health) from PlayerStats.cs
        if (playerStats != null)
        {
            maxHealth = playerStats.GetMaxHealth(); // Gets player's maximum health from playerStats
            SetHealth(playerStats.GetHealth()); // Gets player's starting health from playerStats
        }
    }


    public void UpdateHealth(float amount) // Updates health current health of player
    {
        currHealth += amount;
        UpdateHealthBar();
    }

    public void SetHealth(float newHealth) // Sets current health of player to update before updating health bar
    {
        currHealth = newHealth;
        UpdateHealthBar();
    }
   
    private void UpdateHealthBar() // Updates health bar (UI) whenever there's a change to the player's health
    {
        float optimalFillAmount = currHealth / maxHealth;
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = optimalFillAmount;
        }
    }
}
