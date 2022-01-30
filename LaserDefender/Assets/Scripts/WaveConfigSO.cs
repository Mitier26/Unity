using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스크립터블 오브젝트를 만들 때 사용하는 이름과 만들었을 때 사용되는 이름
[CreateAssetMenu(menuName ="Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject    // 모노비헤이비어가 아니다.
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;  //웨이포인트가 자식으로 있는 부모 오브젝트
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
        // 리스트의 크기를 반환
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
        // 해당 index의 게임오브젝으를 반환
    }

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);  // 부모의 1번 자식을 반환
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        // 향상된 for 문
        // 부모안에 있는 Transform를 child 라는 이름으로 가지고와 리스트에 추가한다.
        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance,
                                        timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
        // 랜덤한 시간을 반환ㄴ
    }
}
