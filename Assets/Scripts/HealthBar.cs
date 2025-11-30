using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   //19. When the player presses the start button, the system shall show the HUD for Health/XP/Level


   private float maxHealth = 100;
   private float currHealth;
   [SerializeField] private Image healthBarFill;
    void Start()
    {
        currHealth = maxHealth;
    }


    public void UpdateHealth(float amount)
    {
        currHealth += amount;
        UpdateHealthBar();
    }
   
    private void UpdateHealthBar()
    {
        float optimalFillAmount = currHealth / maxHealth;
        healthBarFill.fillAmount = optimalFillAmount;
    }
}
