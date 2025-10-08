using UnityEngine;

// Requirement #5
public class PlayerSpawn : MonoBehaviour
{
    public void Spawn(Vector3 playerSpawnPosition)
    {
        gameObject.transform.position = playerSpawnPosition;
        Instantiate(gameObject);
    }
}
