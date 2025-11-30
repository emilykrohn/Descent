using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    private float maxXp = 100;
    private float currXp;
    [SerializeField] private Image xpBarFill;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currXp = 0;
    }

    public void UpdateXp(float amount)
    {
        currXp += amount;
        float newFillAmount = currXp / maxXp;
        xpBarFill.fillAmount = newFillAmount;
    }
}