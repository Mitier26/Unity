using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum SpawnMode
{
    Fixed,Random
}

public class Spawner : MonoBehaviour
{
    public static Action OnWaveCompleted;

    [Header("세팅")]
    [SerializeField] private SpawnMode spawnMode = SpawnMode.Fixed;
    [SerializeField] private int enemyCount = 10;
    [SerializeField] private float delayBtwWaves = 1f;

    [Header("고정 딜레이")]
    [SerializeField] private float delayBtwSpawns;

    [Header("랜덤 딜레이")]
    [SerializeField] private float minRandomDelay;
    [SerializeField] private float maxRandomDelay;

    [Header("풀")]
    [SerializeField] private ObjectPooler enemyWave1To10Pooler;
    [SerializeField] private ObjectPooler enemyWave11To20Pooler;
    [SerializeField] private ObjectPooler enemyWave21To30Pooler;
    [SerializeField] private ObjectPooler enemyWave31To40Pooler;
    [SerializeField] private ObjectPooler enemyWave41To50Pooler;

    private float _spawnTimer;
    private int _enemiesSpawned;
    private int _enemiesRemaining;

    private Waypoint _waypoint;

    private void Start()
    {
        _waypoint = GetComponent<Waypoint>();

        _enemiesRemaining = enemyCount;
    }

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
        GameObject newInstance = GetPoller().GetInstanceFromPool();
        Enemy enemy = newInstance.GetComponent<Enemy>();
        enemy.Waypoint = _waypoint;

        enemy.transform.localPosition = transform.position;
        enemy.ResetEnemy();

        newInstance.SetActive(true);
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

    private ObjectPooler GetPoller()
    {
        int currentWave = LevelManager.Instance.CurrentWave;
        if(currentWave <= 1)
        {
            return enemyWave1To10Pooler;
           
        }

        if(currentWave > 1 && currentWave <= 2)
        {
            return enemyWave11To20Pooler;
        }
        if (currentWave > 2 && currentWave <= 3)
        {
            return enemyWave21To30Pooler;
        }
        if (currentWave > 3 && currentWave <= 4)
        {
            return enemyWave31To40Pooler;
        }
        if (currentWave > 4 && currentWave <= 5)
        {
            return enemyWave41To50Pooler;
        }
        return null;
    }

    private float GetRandomDelay()
    {
        float randomTimer = UnityEngine.Random.Range(minRandomDelay, maxRandomDelay);
        return randomTimer;
    }

    private IEnumerator NextWave()
    {
        yield return new WaitForSeconds(delayBtwSpawns);
        _enemiesRemaining = enemyCount;
        _spawnTimer = 0f;
        _enemiesSpawned = 0;
    }

    private void RecordEnemy(Enemy enmey)
    {
        _enemiesRemaining--;
        if(_enemiesRemaining <= 0)
        {
            OnWaveCompleted?.Invoke();
            StartCoroutine(NextWave());
        }
    }

    void OnEnable()
    {
        Enemy.OnEndReached += RecordEnemy;
        EnemyHealth.OnEnemykilled += RecordEnemy;
    }

    void OnDisable()
    {
        Enemy.OnEndReached -= RecordEnemy;
        EnemyHealth.OnEnemykilled -= RecordEnemy;
    }

    
}
