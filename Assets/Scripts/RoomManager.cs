using UnityEngine;

// Requirement #5
public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerSpawn playerSpawn;

    bool loadNewRoom = false;
    RoomGeneration roomGeneration;

    void Start()
    {
        playerSpawn = player.GetComponent<PlayerSpawn>();
        roomGeneration = gameObject.GetComponent<RoomGeneration>();

        roomGeneration.CreateRoom();
        playerSpawn.Spawn();
    }

    void Update()
    {
        // Makes sure player spawns in after room is generated so it can avoid spawning in a wall
        if (loadNewRoom)
        {
            roomGeneration.CreateRoom();
            playerSpawn.Spawn();
        }
    }
}
