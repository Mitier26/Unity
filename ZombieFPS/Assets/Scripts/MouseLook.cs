using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitvity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    void Start()
    {
        // 화면과 마우스 이동을 고정하는 것
        // 이것이 없으면 화면 따로 마우스 따로 움직이고.
        // 창 모드의 경우 마우스가 창 밖으로 나간다.
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitvity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitvity * Time.deltaTime;
        
        // Y 값은 반전 되어 있으므로 - 를 해 주어야 한다.
        xRotation -= mouseY;
        // 값이 90도 이상으로 움직이지 못하게 하는 것
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
