using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsSave", menuName = "Scriptable Objects/PlayerStatsSave")]
public class PlayerStatsSave : ScriptableObject
{
    [SerializeField] private int attack = 3;
    [SerializeField] private int xp = 0;
    [SerializeField] private int maxXp = 100;
    [SerializeField] private int currentEnemiesDefeated = 0;
    [SerializeField] private int currentFloorNumber = 1;

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