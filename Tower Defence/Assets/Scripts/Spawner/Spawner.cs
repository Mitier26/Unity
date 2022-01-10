using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnMode
{
    Fixed,Random
}

public class Spawner : MonoBehaviour
{
    [Header("ºº∆√")]
    [SerializeField] private SpawnMode spawnMode = SpawnMode.Fixed;
    [SerializeField] private int enemyCount = 10;
    [SerializeField] private GameObject testGO;

    [Header("∞Ì¡§ µÙ∑π¿Ã")]
    [SerializeField] private float delayBtwSpawns;

    [Header("∑£¥˝ µÙ∑π¿Ã")]
    [SerializeField] private float minRandomDelay;
    [SerializeField] private float maxRandomDelay;

    private float _spawnTimer;
    private int _enemiesSpawned;

    // Update is called once per frame
    void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if(_spawnTimer < 0)
        {
            _spawnTimer = GetSpawnDelay();
            if(_enemiesSpawned < enemyCount)
            {
                _enemiesSpawned++;
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(testGO, transform.position, Quaternion.identity);
    }

    private float GetSpawnDelay()
    {
        float delay = 0f;
        if(spawnMode == SpawnMode.Fixed)
        {
            delay = delayBtwSpawns;
        }
        else
        {
            delay = GetRandomDelay();
        }

        return delay;
    }

    private float GetRandomDelay()
    {
        float randomTimer = Random.Range(minRandomDelay, maxRandomDelay);
        return randomTimer;
    }
}
