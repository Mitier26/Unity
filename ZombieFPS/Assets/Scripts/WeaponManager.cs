using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;
    public float range = 100f;
    public float damage = 25f;
    public Animator playerAnimator;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        playerAnimator.SetTrigger("isShooting");
        
        RaycastHit hit;

        if(Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        {
            // 레이저에 맞은 것이 있다면
            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();

            if(enemyManager != null)
            {
                enemyManager.Hit(damage);                
            }
        }
    }
}
