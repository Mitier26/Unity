using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fruitToSpawnPrefabs;
    public GameObject bombPrefab;

    public Transform[] spawnPlaces;
    public int chanceToSpawnBomb = 10;
    public float minWait = 0.3f;
    public float maxWait = 1f;
    public float minForce = 10;
    public float maxForce = 20;

    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            Transform t = spawnPlaces[(Random.Range(0, spawnPlaces.Length))];

            GameObject go = null;
            float rnd = Random.Range(0, 100);

            if(rnd < chanceToSpawnBomb)
            {
                go = bombPrefab;
            }
            else
            {
                go = fruitToSpawnPrefabs[Random.Range(0, fruitToSpawnPrefabs.Length)];
            }

            GameObject fruit = Instantiate(go, t.position, t.rotation);

            // 과일을 위로 발싸하는 부분
            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);
            // 소환기의 위쪽 방향으로 발사 하고 소환기의 회전량에 따라 회전한다.

            Destroy(fruit, 5);
        }
    }
}
