using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVelo = 0.1f;
    Rigidbody2D rb;
    Vector3 lastMousePos;
    Vector3 moveVelo;
    Collider2D collider;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        collider.enabled = IsMouseMoving();
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
