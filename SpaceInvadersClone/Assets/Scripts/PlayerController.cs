using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Rigidbody2D rigidbody;
    Animator animator;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        animator.SetFloat("LeftRight", h);

        Vector2 dir = new Vector2(h,v).normalized;

        rigidbody.velocity = dir * speed;
        //transform.position += dir * speed * Time.deltaTime;

        animator.SetBool("Left", h < 0);
        animator.SetBool("Up", v > 0);
        animator.SetBool("Right", h > 0);
    }
}
