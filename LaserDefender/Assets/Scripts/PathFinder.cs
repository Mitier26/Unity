using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;  // 소환장치를 저장할 변수
    WaveConfigSO waveConfig;
    // 스크립터블 오브젝트를 넣을 변수에는 각 점들의 좌표가 있다.
    List<Transform> waypoints;  // 각 포인트들을 담을 변수
    int waypointIndex = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        // 소환 장치를 찾아서 변수에 넣는다.
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();

        waypoints = waveConfig.GetWaypoints();
        // ScriptableObject에 있는 리스크를 반환하는 메서드
        transform.position = waypoints[waypointIndex].position;
        // 시작 위치를 설정
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            // 현재 위치에서 이동할 좌표
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;   // 이동 속도
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            // MoveTowards(1,2,3)
            // 1 에서 2 까지 3의 속도로 이동
            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
