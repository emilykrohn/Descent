using UnityEngine;
using TMPro;

// Requirement #5
public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerSpawn playerSpawn;

    bool loadNewRoom = true;
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
        // Load new room and update floor number
        if (loadNewRoom)
        {
            PlayerStats playerStats = FindFirstObjectByType<PlayerStats>();
            if (playerStats != null && floorNumberText != null)
            {
                floorNumberText.text = "Floor: " + playerStats.GetCurrentFloorNumber();
            }
            StartNewRoom();
            loadNewRoom = false;
        }
    }

    public void LoadNewRoom()
    {
        loadNewRoom = true;
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