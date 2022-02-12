using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVelo = 0.1f;
    Rigidbody2D rb;
    Vector3 lastMousePos;
    Vector3 moveVelo;
    Collider2D collide;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collide = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        collide.enabled = IsMouseMoving();
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

    // 이것이 무엇이냐?
    // 이것은 마우스가 움직이면 자르는 것이 작동되고
    // 마우스를 움직이지 않으면 잘라지는 것을 끄는 것
    bool IsMouseMoving()
    {
        Vector3 curMousePos = transform.position;
        float traveled = (lastMousePos - curMousePos).magnitude;

        lastMousePos = curMousePos;
        if(traveled > minVelo)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
