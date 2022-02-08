using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraightController : MonoBehaviour
{
    public Vector2 velocity;
    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidbody.velocity = velocity;
    }
}
