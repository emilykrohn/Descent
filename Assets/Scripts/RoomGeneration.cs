using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Requirement #16
public class RoomGeneration : MonoBehaviour
{
    [SerializeField] Tilemap roomFloor;
    [SerializeField] Tilemap roomWalls;
    [SerializeField] List<Tile> tiles = new List<Tile>();
    [SerializeField] int width = 4;
    [SerializeField] int height = 4;
    [SerializeField] float xOrigin = 0f;
    [SerializeField] float yOrigin = 0f;

    [SerializeField] float magnification = 7f;
    [SerializeField] int tileCount = 4;
    [SerializeField] int minFloorTilesAroundPlayer = 20;
    bool isValidMap = false;

    public Vector3 CreateRoom()
    {
        Vector3 playerSpawnPosition = new Vector3();

        while (!isValidMap)
        {
            // If the previous map was not valid, clear all tiles and generate a new map
            roomFloor.ClearAllTiles();
            roomWalls.ClearAllTiles();

            // The offsets make the perlin noise return random values every time this script is run
            float xOffset = Random.Range(0f, 100f);
            float yOffset = Random.Range(0f, 100f);

            bool createdPlayerSpawn = false;

            // x are the horizontal tiles
            for (int x = 0; x < width; x++)
            {
                // y are the vertical tiles
                for (int y = 0; y < height; y++)
                {
                    int tileIndex = CalculateTile(x, y, xOffset, yOffset);
                    Vector3Int position = new Vector3Int(x, y, 0);

                    // Gets position where player can spawn on floor and not in a wall
                    if (!createdPlayerSpawn && tileIndex == 0 && x != 0)
                    {
                        playerSpawnPosition = new Vector3(x + 0.5f, y + 0.5f, 0);
                        createdPlayerSpawn = true;
                    }

                    // Set the tile to the current position and tile type to the room
                    if (tileIndex == 0)
                    {
                        roomFloor.SetTile(position, tiles[tileIndex]);
                    }
                    else if (tileIndex == 1)
                    {
                        roomWalls.SetTile(position, tiles[tileIndex]);
                    }
                }
            }

            isValidMap = CalculateIsValidMap(playerSpawnPosition);
        }
        isValidMap = false; // Reset for next room generation

        return playerSpawnPosition;
    }

    // Use BFS search to count how many floor tiles are surrounding the player
    bool CalculateIsValidMap(Vector3 start)
    {
        Queue<Vector3> queue = new Queue<Vector3>();
        HashSet<Vector3> visited = new HashSet<Vector3>();

        int numberOfTiles = 0; // Count of how many floor tiles are adjacent to the player spawn

        queue.Enqueue(start);
        visited.Add(start);

        // Searches through all possible tiles adjacent to player spawn that could be floor tiles
        while (queue.Count > 0)
        {
            Vector3 currentTile = queue.Dequeue();
            bool hasAdjacentTile = false;

            // If the adjacent tiles has not already been visited, add it to the visited list
            foreach (Vector3 adjacent in FindAdjacentTiles(currentTile))
            {
                if (!visited.Contains(adjacent))
                {
                    queue.Enqueue(adjacent);
                    visited.Add(adjacent);
                    hasAdjacentTile = true;
                }
            }

            if (hasAdjacentTile)
            {
                numberOfTiles++;
            }
        }

        // If not enough floor tiles are around the player, then the map is not valid
        return numberOfTiles > minFloorTilesAroundPlayer;
    }
    
    // Finds the adjacent tiles around the current tile being checked and returns all valid adjacent tiles
    List<Vector3> FindAdjacentTiles(Vector3 current)
    {
        List<Vector3> adjacentList = new List<Vector3>();

        // Tiles that are left, right, up, and down the tile
        Vector3[] directions =
        {
            new Vector3(1.5f, 0, 0), // Right
            new Vector3(-1.5f, 0, 0), // Left
            new Vector3(0, 1.5f, 0), // Up
            new Vector3(0, -1.5f, 0) // Down
        };

        // Checks to see if tiles in the four directions exist
        foreach (Vector3 direction in directions)
        {
            Vector3 adjacentTile = current + direction;
            // Converts to the tilemap coordinate system
            Vector3Int tilePosition = roomFloor.WorldToCell(adjacentTile);
            if (roomFloor.HasTile(tilePosition))
            {
                adjacentList.Add(adjacentTile);
            }
        }

        return adjacentList;
    }

    // Returns the index number of the tile that will be placed at the given x and y values
    // Uses perlin noise to generate which tiles to use
    int CalculateTile(int x, int y, float xOffset, float yOffset)
    {
        // Position where we will get the color from the perlin noise
        float xPosition = (x - xOrigin) / magnification;
        float yPosition = (y - yOrigin) / magnification;

        // Sample gets a float value from the function that represents how light or dark it is
        float sample = Mathf.PerlinNoise(xPosition + xOffset, yPosition + yOffset);

        // The number returned isn't always a number from 0 to 1 so the clamp function fixes that
        float clamped = Mathf.Clamp(sample, 0.0f, 1.0f);

        // float value used as marker for deciding which tile index is returned
        float tileDivider = 1f / tileCount;

        int resultTile = 0;

        // Loops through all tile types
        for (int i = 1; i <= tileCount; i++)
        {
            // i represents the current tile type. if clamped is less than or equal to that then it will be the result tile
            if (clamped <= (tileDivider * i))
            {
                // Subtract one to get the tile index
                resultTile = i - 1;
                break;
            }
        }
        return resultTile;
    }
}
