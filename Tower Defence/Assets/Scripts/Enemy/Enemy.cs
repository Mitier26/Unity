using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] Waypoint waypoint;

    public Vector3 CurrentPointPosition => waypoint.GetWaypointPosition(_currentWaypointIndex);

    private int _currentWaypointIndex;

    private void Start() 
    {
        _currentWaypointIndex = 0;
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
        int lastWayPointIndex = waypoint.Points.Length-1;
        
        if(_currentWaypointIndex < lastWayPointIndex)
        {
            _currentWaypointIndex++;
        }
    }
}
