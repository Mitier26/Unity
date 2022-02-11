using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // 포탑 횐전을 위한 비어있는 오브젝트
    [SerializeField] Transform cannonHead;
    // 레이저가 나가는 위치
    [SerializeField] Transform cannonTip;
    // 공격 대기 시간
    [SerializeField] float shootingCoolDown = 3f;
    [SerializeField] float laserPower = 30;

    bool isPlayerInRange = false;
    GameObject player;
    float timeLeftToShoot = 0;
    LineRenderer cannonLaser;

    void Start()
    {
        cannonLaser = GetComponent<LineRenderer>();
        cannonLaser.sharedMaterial.color = Color.green;
        cannonLaser.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        timeLeftToShoot = shootingCoolDown;
    }

    void Update()
    {
        if(isPlayerInRange) // 범위에 플레이어가 들어 오면
        {
            cannonHead.transform.LookAt(player.transform);  // 플레이어를 바라본다.

            // 라인렌더라를 그린다.
            cannonLaser.SetPosition(0, cannonTip.transform.position);
            cannonLaser.SetPosition(1, player.transform.position);
            // 0은 캐논의 시작점, 1는 플래이어의 위치
            timeLeftToShoot -= Time.deltaTime;
        }

        if(timeLeftToShoot <= shootingCoolDown * 0.5f)  // 3초의 반 1.5초
        {
            cannonLaser.sharedMaterial.color = Color.red;
        }

        if(timeLeftToShoot <= 0)
        {
            Vector3 directionToPuchBack = player.transform.position - cannonTip.transform.position;

            player.GetComponent<Rigidbody>().AddForce(directionToPuchBack * laserPower, ForceMode.Impulse);

            timeLeftToShoot = shootingCoolDown;
            cannonLaser.sharedMaterial.color = Color.green;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            cannonLaser.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            cannonLaser.enabled = false;

            timeLeftToShoot = shootingCoolDown;

            cannonLaser.sharedMaterial.color = Color.green;
        }
    }
}
