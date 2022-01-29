using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;  //Input System을 사용하기 위해 쓰는 것

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;  // 이동 속도

    Vector2 rawInput;   // 이동 방향
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // Ctrl + . 을 하면 평하게 메서드를 만들 수 있다.
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position = delta;
    }

    void OnMove(InputValue value)
    {
        // Input System 에서 제공 하는 메서드,
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }
}
