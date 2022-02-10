using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] float speed = 1;
    Rigidbody rb;
    bool isPlayerInRange = false;

    GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    void FixedUpdate()
    {
        if(isPlayerInRange)
        {
            Vector3 dir = player.transform.position - transform.position;

            rb.AddForce(dir * speed * Time.deltaTime, ForceMode.VelocityChange);

            Vector3 newVelocity = rb.velocity;

            newVelocity.y = 0;
            rb.velocity = newVelocity;
        }
    }

}
