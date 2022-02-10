using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] Transform cannonHead;
    [SerializeField] Transform cannonTip;
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
        if(isPlayerInRange)
        {
            cannonHead.transform.LookAt(player.transform);

            cannonLaser.SetPosition(0, cannonTip.transform.position);

            cannonLaser.SetPosition(1, player.transform.position);

            timeLeftToShoot -= Time.deltaTime;
        }

        if(timeLeftToShoot <= shootingCoolDown * 0.5f)
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
