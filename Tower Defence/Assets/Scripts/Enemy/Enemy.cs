using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public static Action OnEndReached;

    [SerializeField] float moveSpeed = 3f;

    public Waypoint Waypoint { get; set; }

    public Vector3 CurrentPointPosition => Waypoint.GetWaypointPosition(_currentWaypointIndex);

    private int _currentWaypointIndex;
    private EnemyHealth _enemyHealth;

    private void Start() 
    {
        _currentWaypointIndex = 0;
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Update() 
    {
        Move();   

        if(CurrentPointPositionReached())
        {
            UpdateCurrentPointIndex();
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentPointPosition, moveSpeed * Time.deltaTime );
    }

    bool CurrentPointPositionReached()
    {
        float distanceToNextPointPosition = (transform.position - CurrentPointPosition).magnitude;
        
        if(distanceToNextPointPosition < 0.1f)
        {
            return true;
        }

        return false;
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
        OnEndReached?.Invoke();
        _enemyHealth.ResetHealth();
        ObjectPooler.ReturnToPool(gameObject);
    }

    public void ResetEnemy()
    {
        _currentWaypointIndex = 0;
    }
}
