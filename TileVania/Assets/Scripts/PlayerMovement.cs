using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbingSpeed = 5f;
    [SerializeField] Vector2 deathkick = new Vector2(10f, 10f);

    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPos;

    Vector2 moveInput;      //InputSystem 에서 받아오는 값
    Rigidbody2D rigidbody;  // Player의 리기드바디
    Animator animator;      // Player의 애니메이션
    CapsuleCollider2D capsuleCollider;  // Player 몸통 
    BoxCollider2D boxCollider;          // Player 바닥
    float gravityScaleAtStart;          // 중력의 힘

    bool isAlive = true;    // Player 생존

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = rigidbody.gravityScale;
    }

    private void Update()
    {
        // 플레이어가 살아 있을 때만 작동이 되도록 한다.
        if (!isAlive) return;
        Run();
        FlipSprite();
        ClimbingLadder();
        Die();
    }

    void OnMove(InputValue value)
    {
        // Input System에서 제공하는 매서드
        if (!isAlive) return;
        moveInput = value.Get<Vector2>();
    }

    // 점프에 관한 것
    void OnJump(InputValue value)
    {
        // Input System 에서 제공하는 매서드
        if(!boxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
            // Player의 바닥 콜라이더가 바닥과 접촉하고 있지 않다면
            // 아래 것을 실행 하지 않는다.
        }
        if(value.isPressed)
        {
            rigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void OnFire(InputValue value)
    {
        if (!isAlive) return;
        Instantiate(bullet, shootPos.position, shootPos.rotation);
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, rigidbody.velocity.y);
        rigidbody.velocity = playerVelocity;
        // InputSystem에서 받은 값에 속도를 곱하여 이동용 벡터를 만든다.

        // 이동 애니메이션
        bool playerHasHorizontalSpeed = Mathf.Abs(rigidbody.velocity.x) > Mathf.Epsilon;
        // Abs      : 절대값, -19 -> 19 로 마이너스가 없다.
        // Epsilon  : 실수 보정을 위한 최소값, float은 0이 존재하지않는다.
        animator.SetBool("IsRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rigidbody.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidbody.velocity.x), 1f);
            // Sign : 0이거나 양수 이면 1을 반환, 음수이면 -1을 반환
        }

    }
    void ClimbingLadder()
    {
        if (!boxCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            rigidbody.gravityScale = gravityScaleAtStart;
            animator.SetBool("IsCliming", false);
            return;
        }

        Vector2 climbingVelocity = new Vector2(rigidbody.velocity.x, moveInput.y * climbingSpeed);
        rigidbody.velocity = climbingVelocity;
        rigidbody.gravityScale = 0;

        bool playerHasVerticalSpeed = Mathf.Abs(rigidbody.velocity.y) > Mathf.Epsilon;

        animator.SetBool("IsCliming", playerHasVerticalSpeed);

    }

    void Die()
    {
        // 죽었을 때 실행되는 것
        if(capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazard")))
        {
            isAlive = false;
            animator.SetTrigger("Dying");
            rigidbody.velocity = deathkick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}
