using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    int attack = 3;
    int xp = 0;
    int maxXp = 100;
    int currentEnemiesDefeated = 0;
    int currentFloorNumber = 1;

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
