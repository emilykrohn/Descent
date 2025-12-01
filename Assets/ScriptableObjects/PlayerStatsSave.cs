using Unity.VisualScripting;
using UnityEngine;

// Requirement #2
[CreateAssetMenu(fileName = "PlayerStatsSave", menuName = "Scriptable Objects/PlayerStatsSave")]
public class PlayerStatsSave : ScriptableObject
{
    [SerializeField] private int health = 100;
    [SerializeField] private int attack = 3;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int xp = 0;
    [SerializeField] private int maxXp = 100;
    [SerializeField] private int level = 0;
    [SerializeField] private int currentEnemiesDefeated = 0;
    [SerializeField] private int currentFloorNumber = 1;

    

    public int GetHealth()
    {
        return health;
    }
    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public float GetSpeed()
    {
        return speed;
    }
    public int GetAttack()
    {
        return attack;
    }
    public void SetAttack(int newAttack)
    {
        attack = newAttack;
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
    public int GetLevel()
    {
        return level;
    }
    public void SetLevel(int newLevel)
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