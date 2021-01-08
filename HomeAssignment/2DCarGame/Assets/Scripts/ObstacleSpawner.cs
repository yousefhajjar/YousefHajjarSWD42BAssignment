﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigList;

    [SerializeField] bool looping = false;

    int startingWave = 0;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }


    void Update()
    {

    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveToSpawn)
    {
        for (int enemyCount = 1; enemyCount <= waveToSpawn.GetNumberOfObstacles(); enemyCount++)
        {
            var newEnemy = Instantiate(
                            waveToSpawn.GetObstaclePrefab(),
                            waveToSpawn.GetWaypoints()[0].transform.position,
                            Quaternion.identity);

            newEnemy.GetComponent<ObstaclePathing>().SetWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }
    }

    private IEnumerator SpawnAllWaves()
    {
        foreach (WaveConfig currentWave in waveConfigList)
        {
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
}
