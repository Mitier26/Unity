using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SetBladeToMouse();
    }

    void SetBladeToMouse()
    {
        // 중요한것은 여기에 있다.
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
        // 마우스의 위치를 가지고 온다.
        // 마우스의 위치에서 10을 더한다. 더하는 값은 카메라의 위치이다.
        // Rigidbody의 위치를 변경한다.
    }
}
