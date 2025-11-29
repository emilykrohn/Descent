using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    int attack = 3;

    public int GetAttack()
    {
        return attack;
    }
    public void SetAttack(int newAttack)
    {
        attack = newAttack;
    }
}
