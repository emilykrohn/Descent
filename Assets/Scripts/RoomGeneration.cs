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

    public Vector3 CreateRoom()
    {
        // The offsets make the perlin noise return random values every time this script is run
        float xOffset = Random.Range(0f, 100f);
        float yOffset = Random.Range(0f, 100f);

        bool createdPlayerSpawn = false;
        Vector3 playerSpawnPosition = new Vector3();

        // x are the horizontal tiles
        for (int x = 0; x < width; x++)
        {
            // y are the vertical tiles
            for (int y = 0; y < height; y++)
            {
                int tileIndex = CalculateTile(x, y, xOffset, yOffset);
                Vector3Int position = new Vector3Int(x, y, 0);

                // Gets position where player can spawn on floor and not in a wall
                if (!createdPlayerSpawn && tileIndex == 0)
                {
                    playerSpawnPosition = new Vector3(x + 0.5f, y + 0.5f, 0);
                    Debug.Log(playerSpawnPosition);
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

        return playerSpawnPosition;
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
