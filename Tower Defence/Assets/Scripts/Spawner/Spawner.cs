using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnMode
{
    Fixed,Random
}

public class Spawner : MonoBehaviour
{
    [Header("세팅")]
    [SerializeField] private SpawnMode spawnMode = SpawnMode.Fixed;
    [SerializeField] private int enemyCount = 10;
    [SerializeField] private float delayBtwWaves = 1f;

    [Header("고정 딜레이")]
    [SerializeField] private float delayBtwSpawns;

    [Header("랜덤 딜레이")]
    [SerializeField] private float minRandomDelay;
    [SerializeField] private float maxRandomDelay;

    private float _spawnTimer;
    private int _enemiesSpawned;
    private int _enemiesRemaining;

    private ObjectPooler _pooler;

    private Waypoint _waypoint;

    private void Start()
    {
        _pooler = GetComponent<ObjectPooler>();
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
        GameObject newInstance = _pooler.GetInstanceFromPool();
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

    private float GetRandomDelay()
    {
        float randomTimer = Random.Range(minRandomDelay, maxRandomDelay);
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
