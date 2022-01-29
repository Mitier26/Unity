using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;  //Input System을 사용하기 위해 쓰는 것

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;  // 이동 속도
    Vector2 rawInput;   // 이동 방향

    // 오브젝트가 이동 할 수 있는 공간을 제한한다.
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    // 화면의 최소, 최대 값을 저장하기 위한 변수
    Vector2 minBounds;
    Vector2 maxBounds;

    void Start()
    {
        InitBounds();
    }

    private void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        // 카메라가 보고 있는 크기에서 만들어야 한다.
        // 카메라의 0,0 과 1,1 의 값을 월드좌표로 변환하여 저장한다.
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void Move()
    {
        // Ctrl + . 을 하면 평하게 메서드를 만들 수 있다.
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        //Clamp (1, 2, 3)
        // 1을 2(최소값) 에서 3(최대값) 사이의 값만 가지도록  한다.
        // delta : 이동
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        // Input System 에서 제공 하는 메서드,
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }
}
