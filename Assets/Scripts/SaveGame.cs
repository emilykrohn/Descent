using UnityEngine;

public class SaveGame : MonoBehaviour
{
    PlayerStats playerStats;
    [SerializeField] PlayerStatsSave playerStatsSave;
    void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
    }
    public void Save()
    {
        playerStatsSave.SetAttack(playerStats.GetAttack());
        playerStatsSave.SetXP(playerStats.GetXP());
        playerStatsSave.SetMaxXP(playerStats.GetMaxXP());
        playerStatsSave.SetCurrentEnemiesDefeated(playerStats.GetCurrentEnemiesDefeated());
        playerStatsSave.SetCurrentFloorNumber(playerStats.GetCurrentFloorNumber());
    }
}
