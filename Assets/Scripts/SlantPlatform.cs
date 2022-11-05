using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlantPlatform : MonoBehaviour
{
    [SerializeField]
    private float _rotationAngle;
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private float _diagonalModify;
    private float _horizontal;
    private float _vertical;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }
    private void Update()
    {
        RotatePlatform();
    }

    private void RotatePlatform()
    {
        Quaternion transformRotation = _transform.rotation;
        _transform.rotation = Quaternion.Lerp(transformRotation, CalculateRotation(), Time.deltaTime * _rotationSpeed);
    }

    private Quaternion CalculateRotation()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        if (Math.Abs(_horizontal) - Math.Abs(_vertical) == 0)
        {
            _horizontal /= _diagonalModify;
            _vertical /= _diagonalModify;
        }
        Vector3 direction = new Vector3(_vertical, 0, -_horizontal) * _rotationAngle;
        return Quaternion.Euler(direction);
    }
}
