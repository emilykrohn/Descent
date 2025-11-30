using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    int attack = 3;
    int xp = 0;
    int maxXp = 100;

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
}
