using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAsteroids : MonoBehaviour
{
    public GameObject AsteroidPrefab;
    [SerializeField] private int NumberOfAsteroidsOnAxisX = 10;
    [SerializeField] private int NumberOfAsteroidsOnAxisY = 10;
    [SerializeField] private int NumberOfAsteroidsOnAxisZ = 10;
    [SerializeField] private int GridSpacing = 10;

    private void Start()
    {
        for(int i = 0; i< NumberOfAsteroidsOnAxisX; i++)
        {
            for (int j = 0; j < NumberOfAsteroidsOnAxisY; j++)
            {
                for (int k = 0; k < NumberOfAsteroidsOnAxisZ; k++)
                {
                    InstantiateAsteroids(i, j, k);
                }
            }
        }
    }

    private void InstantiateAsteroids(int x, int y, int z)
    {
        Instantiate(AsteroidPrefab, new Vector3(
            transform.position.x + x * GridSpacing + OffsetAsteroid(),
            transform.position.y + y * GridSpacing + OffsetAsteroid(),
            transform.position.z + z * GridSpacing + OffsetAsteroid()), Quaternion.identity, transform);
    }

    private float OffsetAsteroid()
    {
        return Random.Range(-GridSpacing/2f, GridSpacing/2f);
    }
}
