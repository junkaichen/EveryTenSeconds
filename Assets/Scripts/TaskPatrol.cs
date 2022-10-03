using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.UIElements;

public class TaskPatrol : Node
{
    private Transform _tranform;
    private Transform[] _waypoints;
    private int _currentWaypointIndex = 0;
    private float _waitTime = 1f;
    private float _waitCounter = 0f;
    private bool _waiting = false;

    public TaskPatrol(Transform transform, Transform[] waypoints)
    { 
        _tranform = transform;
        _waypoints = waypoints;
    }
    public override NodeState Evaluate()
    {
        if (_waiting)
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter >= _waitTime)
                _waiting = false;
        }
        else 
        {
            Transform wp = _waypoints[_currentWaypointIndex];
            if (Vector3.Distance(_tranform.position, wp.position) < 0.01f)
            {
                _tranform.position = wp.position;
                _waitCounter = 0f;
                _waiting = true;

                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            }
            else
            {
                /*_tranform.position = Vector3.MoveTowards(_tranform.position, wp.position, _speed * Time.deltaTime);*/
            }
        }
        state = NodeState.RUNNING;
        return state;
    }
}
