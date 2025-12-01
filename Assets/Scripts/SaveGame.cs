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
        if (playerStats != null)
        {
            playerStatsSave.SetHealth(playerStats.GetHealth());
            playerStatsSave.SetAttack(playerStats.GetAttack());
            playerStatsSave.SetSpeed(playerStats.GetSpeed());
            playerStatsSave.SetXP(playerStats.GetXP());
            playerStatsSave.SetMaxXP(playerStats.GetMaxXP());
            playerStatsSave.SetLevel(playerStats.GetCurrentLevel());
            playerStatsSave.SetCurrentEnemiesDefeated(playerStats.GetCurrentEnemiesDefeated());
            playerStatsSave.SetCurrentFloorNumber(playerStats.GetCurrentFloorNumber());
        }
    }
}
