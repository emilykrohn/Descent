using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    int health = 100;
    int attack = 3;
    float speed = 5f;
    int xp = 0;
    int maxXp = 100;
    int level = 0;
    int currentEnemiesDefeated = 0;
    int currentFloorNumber = 1;
    [SerializeField] private PlayerStatsSave playerStatsSave;
    private XpBar xpBar;
    private HealthBar healthBar;

    public int GetHealth()
    {
        return health;
    }
    public void SetHealth(int newHealth)
    {
        health = newHealth;
        if (healthBar != null)
        {
            healthBar.SetHealth(health);
        }
    }

    public int GetAttack()
    {
        return attack;
    }
    public void SetAttack(int newAttack)
    {
        attack = newAttack;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public int GetXP()
    {
        return xp;
    }
    public void SetXP(int newXP)
    {
        xp = newXP;
    }

    public int GetMaxXP()
    {
        return maxXp;
    }
    public void SetMaxXP(int newMaxXP)
    {
        maxXp = newMaxXP;
    }
    public int GetCurrentLevel()
    {
        return level;
    }
    public void SetCurrentLevel(int newLevel)
    {
        level = newLevel;
    }

    public int GetCurrentEnemiesDefeated()
    {
        return currentEnemiesDefeated;
    }
    public void SetCurrentEnemiesDefeated(int newCurrentEnemiesDefeated)
    {
        currentEnemiesDefeated = newCurrentEnemiesDefeated;
    }

    public int GetCurrentFloorNumber()
    {
        return currentFloorNumber;
    }
    public void SetCurrentFloorNumber(int newCurrentFloorNumber)
    {
        currentFloorNumber = newCurrentFloorNumber;
    }
}
