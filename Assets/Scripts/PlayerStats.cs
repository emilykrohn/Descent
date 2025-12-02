using UnityEngine;

// Requirement #2
public class PlayerStats : MonoBehaviour
{
    int health = 500;
    int attack = 3;
    float speed = 5f;
    int xp = 0;
    int maxXp = 100;
    int level = 0;
    int currentEnemiesDefeated = 0;
    int currentFloorNumber = 1;

    public void ResetStats()
    {
        health = 500;
        attack = 3;
        speed = 5f;
        xp = 0;
        maxXp = 100;
        level = 0;
        currentEnemiesDefeated = 0;
        currentFloorNumber = 1;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public int GetHealth()
    {
        return health;
    }
    public void SetHealth(int newHealth)
    {
        health = newHealth;
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
