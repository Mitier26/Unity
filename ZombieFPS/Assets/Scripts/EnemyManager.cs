using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public Animator enemyAnimator;
    public float damage = 20f;
    public float health = 100f;
    
    public GameManager gameManager;

    public void Hit(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            gameManager.enemiesAlive--;
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Player를 찾는다.
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // 네비메쉬의 도착 지점을 플레이어의 위치로 지정한다.
        GetComponent<NavMeshAgent>().destination = player.transform.position;

        // 값의 길이가 1 이상이면 애니메이션을 작동한다.
        if(GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            enemyAnimator.SetBool("isRunning", true);
        }
        else
        {
            enemyAnimator.SetBool("isRunning", false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            // 플레이어를 공격하는 곳
            player.GetComponent<PlayerManager>().Hit(damage);
        }
    }
}
