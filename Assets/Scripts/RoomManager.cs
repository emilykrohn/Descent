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
        playerSpawn = player.GetComponent<PlayerSpawn>();
    }

    void Update()
    {
        if (loadNewRoom)
        {
            PlayerStats playerStats = FindFirstObjectByType<PlayerStats>();
            floorNumberText.text = "Floor: " + playerStats.GetCurrentFloorNumber();
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
        Vector3 playerSpawnPosition = roomGeneration.CreateRoom();
        playerSpawn.Spawn(playerSpawnPosition);
        enemySpawner.Spawn();
    }
}
