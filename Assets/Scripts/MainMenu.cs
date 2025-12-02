using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Requirement 19
public class MainMenu : MonoBehaviour
{
    [SerializeField] PlayerStatsSave playerStatsSave;
    PlayerStats playerStats;

    public void PlayGame()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.ResetStats();
        }
        SceneManager.LoadSceneAsync(1);
    }

    public void ControlsScene()
    {
        SceneManager.LoadScene(2);
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void Load()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
        if (playerStats != null && playerStatsSave != null)
        {
            playerStats.SetHealth(playerStatsSave.GetHealth());
            playerStats.SetAttack(playerStatsSave.GetAttack());
            playerStats.SetSpeed(playerStatsSave.GetSpeed());
            playerStats.SetXP(playerStatsSave.GetXP());
            playerStats.SetMaxXP(playerStatsSave.GetMaxXP());
            playerStats.SetCurrentLevel(playerStatsSave.GetLevel());
            playerStats.SetCurrentEnemiesDefeated(playerStatsSave.GetCurrentEnemiesDefeated());
            playerStats.SetCurrentFloorNumber(playerStatsSave.GetCurrentFloorNumber());
        }
        SceneManager.LoadSceneAsync(1);
    }
}
