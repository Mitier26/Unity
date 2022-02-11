using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fruitToSpawnPrefab;
    public Transform[] spawnPlaces;
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

            GameObject fruit = Instantiate(fruitToSpawnPrefab, t.position, t.rotation);

            // 과일을 위로 발싸하는 부분
            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);
            // 소환기의 위쪽 방향으로 발사 하고 소환기의 회전량에 따라 회전한다.

            Destroy(fruit, 5);
        }
    }
}
