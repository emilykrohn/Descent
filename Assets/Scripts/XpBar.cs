using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XpBar : MonoBehaviour
{
    private float maxXp = 100;
    private float currXp;
    private int currLevel = 0;
    [SerializeField] private Image xpBarFill;
    [SerializeField] private TextMeshProUGUI xpText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currXp = 0;
        maxXp = FindFirstObjectByType<PlayerStats>().GetMaxXP();
    }

    public void UpdateXp(float amount)
    {
        currXp += amount;
        if (currXp > maxXp)
        {
            currXp -= maxXp;
            currLevel++;
            xpText.text = "XP Level: " + currLevel;
            PowerUpUI powerUpUI = FindFirstObjectByType<PowerUpUI>();
            powerUpUI.OpenUI();
        }
        float newFillAmount = currXp / maxXp;
        xpBarFill.fillAmount = newFillAmount;
    }
}