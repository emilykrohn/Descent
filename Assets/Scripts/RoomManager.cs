using UnityEngine;
using TMPro;
using Unity.VisualScripting;

// Requirement #5
public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerSpawn playerSpawn;

    [SerializeField] RoomGeneration roomGeneration;
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] TextMeshProUGUI floorNumberText;

    void Start()
    {
        if (player != null)
        {
            playerSpawn = player.GetComponent<PlayerSpawn>();
        }
    }

    void Update()
    {
        EnemyMovement enemyMovement = FindFirstObjectByType<EnemyMovement>();
        // Load new room and update floor number
        if (enemyMovement == null)
        {
            PlayerStats playerStats = FindFirstObjectByType<PlayerStats>();
            if (playerStats != null && floorNumberText != null)
            {
                playerStats.SetCurrentFloorNumber(playerStats.GetCurrentFloorNumber() + 1);
                floorNumberText.text = "Floor: " + playerStats.GetCurrentFloorNumber();
            }
            StartNewRoom();
        }
    }

    void StartNewRoom()
    {
        // Makes sure player spawns in after room is generated so it can avoid spawning in a wall
        if (roomGeneration != null)
        {
            Vector3 playerSpawnPosition = roomGeneration.CreateRoom();
            if (playerSpawn != null)
            {
                playerSpawn.Spawn(playerSpawnPosition);
            }
            if (enemySpawner != null)
            {
                enemySpawner.Spawn();
            }
        }
    }
}