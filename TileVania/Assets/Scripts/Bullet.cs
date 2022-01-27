using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    Rigidbody2D rb;
    PlayerMovement palyer;
    float xSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        palyer = FindObjectOfType<PlayerMovement>();
        xSpeed = palyer.transform.localScale.x * bulletSpeed;
    }

    private void Update()
    {
        rb.velocity = new Vector2(xSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
