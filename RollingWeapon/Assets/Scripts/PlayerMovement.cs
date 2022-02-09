using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    float hozInput, vertInput;
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 10f;
    public bool isJumpButtonPressed;
    public bool isGround;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        hozInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJumpButtonPressed = true;
        }
        
    }

    void FixedUpdate()
    {
        Vector3 playerMovement = new Vector3(hozInput,0, vertInput);
        playerMovement *= speed;
        rb.AddForce(playerMovement, ForceMode.Acceleration);

        // 아래 있는 CollisionEnter를 사용할 경우
        // 공이 바닥에 있지만 isGround가 작동 하지 않는다.
        // 그리고 벽에 붙어있을 때 점프가 되는 현상이 있다.
        // 오로지 공의 바닥만 체크하여 점프를 하도록 해야 한다.
        // Ray를 이용하면 특정한 위치만 측정이 가능하다.
        Ray ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray, transform.localScale.x / 2f + 0.01f))
        // 공의 크기에서 반 : 0.5 -> 이 것은 공의 높이 랑 같다.
        // 0.01을 더하여 조금더 아래를 측정하도록 한다.
        // 측정의 정확도를 위한것
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

        if(isJumpButtonPressed && isGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumpButtonPressed = false;
        }
    }

    // void OnCollisionEnter(Collision other)
    // {
    //     isGround = true;
    // }

    // void OnCollisionExit(Collision other)
    // {
    //     isGround = false;
    // }
}
