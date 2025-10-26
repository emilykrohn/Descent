using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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
            Vector3 spawnLocation = new Vector3(Random.Range(bounds.x, bounds.xMax), Random.Range(bounds.y, bounds.yMax), 0);
            if (!spawnedLocationList.Contains(spawnLocation))
            {
                TileBase tile = floorTiles[(int)spawnLocation.x + (int)spawnLocation.y];
                if (tile)
                {
                    Instantiate(enemy, new Vector3(spawnLocation.x, spawnLocation.y, 0), Quaternion.identity);
                    currentEnemiesSpawned++;
                    spawnedLocationList.Add(spawnLocation);
                    Debug.Log(spawnedLocationList);
                }
            }
        }
    }
}
