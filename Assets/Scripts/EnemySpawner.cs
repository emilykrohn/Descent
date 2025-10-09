using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    public void Spawn()
    {
        Instantiate(enemy);
    }
}
