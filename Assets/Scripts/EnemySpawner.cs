using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Requirement #8
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Tilemap floorTilemap;
    [SerializeField] int totalEnemiesSpawned = 5;
    int currentEnemiesSpawned = 0;
    List<Vector3> spawnedLocationList = new List<Vector3>();

    public void Spawn()
    {
        BoundsInt bounds = floorTilemap.cellBounds;
        TileBase[] floorTiles = floorTilemap.GetTilesBlock(bounds);

        while (currentEnemiesSpawned < totalEnemiesSpawned)
        {
            // Get random spawn location within the floor tile map bounds
            Vector3 spawnLocation = new Vector3(Random.Range(bounds.x, bounds.xMax), Random.Range(bounds.y, bounds.yMax), 0);
            // Makes sure that a different enemy isn't already at that location
            if (!spawnedLocationList.Contains(spawnLocation))
            {
                TileBase tile = floorTiles[(int)spawnLocation.x + (int)spawnLocation.y];
                // Makes sure that the tile exists in the floor tilemap
                if (tile)
                {
                    // Spawn the enemy at the location
                    Instantiate(enemy, new Vector3(spawnLocation.x, spawnLocation.y, 0), Quaternion.identity);
                    currentEnemiesSpawned++;
                    spawnedLocationList.Add(spawnLocation);
                }
            }
        }
    }
}
