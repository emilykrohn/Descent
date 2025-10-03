using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomGeneration : MonoBehaviour
{
    [SerializeField] Tilemap roomMap;
    [SerializeField] List<Tile> tiles = new List<Tile>();
    [SerializeField] int width = 4;
    [SerializeField] int height = 4;
    [SerializeField] float xOrigin = 0;
    [SerializeField] float yOrigin = 0;
    [SerializeField] float magnification = 7f;
    [SerializeField] int tileCount = 4;
    [SerializeField] int tileSize = 16;

    void Start()
    {
        CreateRoom();
    }

    void CreateRoom()
    {
        // x are the horizontal tiles
        for (int x = 0; x < width; x++)
        {
            // y are the vertical tiles
            for (int y = 0; y < height; y++)
            {
                int tileIndex = CalculateTile(x, y);
                Vector3Int position = new Vector3Int(x, y, 0);
                roomMap.SetTile(position, tiles[tileIndex]);
            }
        }
    }

    // Returns the index number of the tile that will be placed at the given x and y values
    // Uses perlin noise to generate which tiles to use
    int CalculateTile(int x, int y)
    {
        // Position where we will get the color from the perlin noise
        float xPosition = (x - xOrigin) / magnification;
        float yPosition = (y - yOrigin) / magnification;

        // Sample gets a float value from the function that represents how light or dark it is
        float sample = Mathf.PerlinNoise(xPosition, yPosition);

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
