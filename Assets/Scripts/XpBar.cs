using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class XpBar : MonoBehaviour
{
    private int startingMaxXp = 100;
    private int maxXp = 100;
    private int currXp = 0;
    private int currLevel = 0;
    private PlayerStats playerStats;
    [SerializeField] private Image xpBarFill;
    [SerializeField] private TextMeshProUGUI xpText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currXp = 0;
        playerStats = FindFirstObjectByType<PlayerStats>();
        if (playerStats != null)
        {
            maxXp = playerStats.GetMaxXP();
        }
    }

    public void UpdateXp(int amount)
    {
        currXp += amount;
        if (playerStats != null)
        {
            playerStats.SetXP(currXp);
            // If the current xp is greater than the max xp, increase the players level and open the power up UI
            if (currXp >= maxXp)
            {
                // Decrease current xp by max xp to carry over extra xp to next level
                currXp -= maxXp;
                playerStats.SetXP(currXp);
                currLevel++;
                playerStats.SetCurrentLevel(currLevel);
                // Increase max xp for next level
                maxXp = startingMaxXp + (int)Math.Pow(currLevel, 1.8);
                playerStats.SetMaxXP(maxXp);
                // Update the xp text
                if (xpText != null)
                {
                    xpText.text = "XP Level: " + currLevel;
                }
                PowerUpUI powerUpUI = FindFirstObjectByType<PowerUpUI>();
                if (powerUpUI != null)
                {
                    powerUpUI.OpenUI();
                }
            }
        }
        // Update the fill amount of the xp bar
        float newFillAmount = (float)currXp / maxXp;
        if (xpBarFill != null)
        {
            xpBarFill.fillAmount = newFillAmount;
        }
    }

    public void SetXp(int newXp)
    {
        currXp = newXp;
        // Update the fill amount of the xp bar
        float newFillAmount = (float)currXp / maxXp;
        if (xpBarFill != null)
        {
            xpBarFill.fillAmount = newFillAmount;
        }
        if (playerStats != null)
        {
            if (xpText != null)
            {
                xpText.text = "XP Level: " + playerStats.GetCurrentLevel();;
            }
        }
    }
}