using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform cameraTarget;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothTime = 0.3f;
    Vector3 cameraVelocity = Vector3.zero;

    void Start()
    {
        cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - cameraTarget.position;
    }
    
    void LateUpdate()
    {
        Vector3 targetPosition = cameraTarget.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothTime);

        transform.LookAt(cameraTarget);
    }

}
