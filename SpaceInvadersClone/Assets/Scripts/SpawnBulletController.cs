using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBulletController : MonoBehaviour
{
    [SerializeField] GameObject buttlet;
    [SerializeField] float interval = 1.0f;

    void Start()
    {
        InvokeRepeating("ShootBullet", interval, interval);
    }

    void Update()
    {
        
    }

    void ShootBullet()
    {
        GameObject b = Instantiate(buttlet, transform.position, Quaternion.identity);
    }


}
