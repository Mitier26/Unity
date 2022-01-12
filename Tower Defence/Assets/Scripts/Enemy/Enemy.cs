using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public static Action<Enemy> OnEndReached;

    [SerializeField] float moveSpeed = 3f;

    public float MoveSpeed { get; set; }

    public Waypoint Waypoint { get; set; }

    public Vector3 CurrentPointPosition => Waypoint.GetWaypointPosition(_currentWaypointIndex);

    private int _currentWaypointIndex;

    private Vector3 _lastPointPosition;

    private EnemyHealth _enemyHealth;
    private SpriteRenderer _spriteRenderer;

    private void Start() 
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        _currentWaypointIndex = 0;
        MoveSpeed = moveSpeed;
        _lastPointPosition = transform.position;

    }

    private void Update() 
    {
        Move();   
        Rotate();

        if(CurrentPointPositionReached())
        {
            UpdateCurrentPointIndex();
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentPointPosition, MoveSpeed * Time.deltaTime );
    }

    private void Rotate()
    {
        if(CurrentPointPosition.x > _lastPointPosition.x)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }
    }

    bool CurrentPointPositionReached()
    {
        float distanceToNextPointPosition = (transform.position - CurrentPointPosition).magnitude;
        
        if(distanceToNextPointPosition < 0.1f)
        {
            _lastPointPosition = transform.position;
            return true;
        }

        return false;
    }

    public void StopMovement()
    {
        MoveSpeed = 0f;
    }
    public void ResumMovement()
    {
        MoveSpeed = moveSpeed;
    }

    void UpdateCurrentPointIndex()
    {
        int lastWayPointIndex = Waypoint.Points.Length-1;

        if(_currentWaypointIndex < lastWayPointIndex)
        {
            _currentWaypointIndex++;
        }
        else
        {
            EndPointReached();
        }
    }

    void EndPointReached()
    {
        OnEndReached?.Invoke(this);
        _enemyHealth.ResetHealth();
        ObjectPooler.ReturnToPool(gameObject);
    }

    public void ResetEnemy()
    {
        _currentWaypointIndex = 0;
    }
}
