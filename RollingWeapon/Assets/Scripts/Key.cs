using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] Door doorToUnlock;
    [SerializeField] float keyRotationSpeed;

    void Update()
    {
        //transform.Rotate(Vector3.up * Time.deltaTime * keyRotationSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            doorToUnlock.UnlockDoor();
            gameObject.SetActive(false);
        }
    }

    void OnDrawGizmos()
    {
        if(doorToUnlock != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, doorToUnlock.transform.position - transform.position);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position + Vector3.up * 2, 0.5f);
        }
    }
}
