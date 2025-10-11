using UnityEngine;

// Requirement #5
public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerSpawn playerSpawn;

    bool loadNewRoom = false;
    [SerializeField] RoomGeneration roomGeneration;
    [SerializeField] EnemySpawner enemySpawner;

    void Start()
    {
        playerSpawn = player.GetComponent<PlayerSpawn>();

        Vector3 playerSpawnPosition = roomGeneration.CreateRoom();
        playerSpawn.Spawn(playerSpawnPosition);
        enemySpawner.Spawn();
    }

    void Update()
    {
        // Makes sure player spawns in after room is generated so it can avoid spawning in a wall
        if (loadNewRoom)
        {
            Vector3 playerSpawnPosition = roomGeneration.CreateRoom();
            playerSpawn.Spawn(playerSpawnPosition);
        }
    }
}
