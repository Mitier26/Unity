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
    Vector2 moveInput;
    Rigidbody2D rigidbody;
    Animator animator;
    CapsuleCollider2D capsuleCollider;
    float gravityScaleAtStart;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = rigidbody.gravityScale;
    }

    private void Update()
    {
        Run();
        FlipSprite();
        ClimbingLadder();
    }

    

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // 점프에 관한 것
    void OnJump(InputValue value)
    {
        if(!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if(value.isPressed)
        {
            rigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, rigidbody.velocity.y);
        rigidbody.velocity = playerVelocity;

        // 이동 애니메이션
        bool playerHasHorizontalSpeed = Mathf.Abs(rigidbody.velocity.x) > Mathf.Epsilon;
        animator.SetBool("IsRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rigidbody.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidbody.velocity.x), 1f);
        }

    }
    void ClimbingLadder()
    {
        if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
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
}
