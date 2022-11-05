using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Rigidbody _rigidbody;
    private Vector3 _moveDirection;
    private Transform _transform;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
        _moveDirection = _transform.forward;
    }

    private void FixedUpdate()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        var velocity = _rigidbody.velocity;
        float x = velocity.x;
        float y = velocity.y;
        _rigidbody.velocity = new Vector3(x, y, _moveDirection.z * _speed);
    }
    
}
