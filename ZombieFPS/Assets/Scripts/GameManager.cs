using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int enemiesAlive = 0;

    public int round = 0;

    public GameObject[] spawnPoints;

    public GameObject enemyPrefab;

    void Update()
    {
        if(enemiesAlive == 0)
        {
            round++;
            NextWave(round);
        }
    }

    public void NextWave(int round)
    {
        for(var x = 0; x< round; x++)
        {
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            GameObject eneySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            eneySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();

            enemiesAlive++;
        }

    }
}
