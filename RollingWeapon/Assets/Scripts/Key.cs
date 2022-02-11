using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // 문에 열결해 문에 있는 것을 접근하기위해
    [SerializeField] Door doorToUnlock;
    [SerializeField] float keyRotationSpeed;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            doorToUnlock.UnlockDoor();
            gameObject.SetActive(false);
        }
    }

    // 화면에 그림을 그리는 부분 Game 창에는 보이지 않는다.
    void OnDrawGizmos()
    {
        if(doorToUnlock != null)
        {
            // 문과 연결되어 있으면 녹색선
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, doorToUnlock.transform.position - transform.position);
        }
        else
        {
            // 문과 연결되어 있지 않다면 빨간원
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position + Vector3.up * 2, 0.5f);
        }
        // 을 보여준다.
        // 스트립트 에러를 위해 사용하면 좋다.
    }
}