using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{

    [SerializeField] GameObject ObstaclePrefab;

    [SerializeField] GameObject pathPrefab;

    [SerializeField] float timeBetweenSpawns = 1f;

    [SerializeField] float spawnRandomFactor = 0.3f;

    [SerializeField] int numberOfObstacles = 1;

    [SerializeField] float ObstacleMoveSpeed = 8f;

    public GameObject GetEnemyPrefab()
    {
        return ObstaclePrefab;
    }

    public List<Transform> GetWaypoints()
    {
        var waveWayPoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }

        return waveWayPoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfObstacles;
    }

    public float GetEnemyMoveSpeed()
    {
        return ObstacleMoveSpeed;
    }
}
