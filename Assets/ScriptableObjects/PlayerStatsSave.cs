using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsSave", menuName = "Scriptable Objects/PlayerStatsSave")]
public class PlayerStatsSave : ScriptableObject
{
    [SerializeField] private int attack = 3;
    [SerializeField] private int xp = 0;
    [SerializeField] private int maxXp = 100;
    [SerializeField] private int currentEnemiesDefeated = 0;
    [SerializeField] private int currentFloorNumber = 1;
}
