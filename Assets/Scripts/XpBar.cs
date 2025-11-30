using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XpBar : MonoBehaviour
{
    private int maxXp = 100;
    private int currXp;
    private int currLevel = 0;
    private PlayerStats playerStats;
    [SerializeField] private Image xpBarFill;
    [SerializeField] private TextMeshProUGUI xpText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currXp = 0;
        playerStats = FindFirstObjectByType<PlayerStats>();
        maxXp = playerStats.GetMaxXP();
    }

    public void UpdateXp(int amount)
    {
        currXp += amount;
        // If the current xp is greater than the max xp, increase the players level and open the power up UI
        if (currXp > maxXp)
        {
            // Decrease current xp by max xp to carry over extra xp to next level
            currXp -= maxXp;
            playerStats.SetXP(currXp);
            currLevel++;
            playerStats.SetCurrentLevel(currLevel);
            // Update the xp text
            xpText.text = "XP Level: " + currLevel;
            PowerUpUI powerUpUI = FindFirstObjectByType<PowerUpUI>();
            powerUpUI.OpenUI();
        }
        // Update the fill amount of the xp bar
        float newFillAmount = currXp / maxXp;
        xpBarFill.fillAmount = newFillAmount;
    }
}