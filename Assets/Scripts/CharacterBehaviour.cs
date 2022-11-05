using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;
    [SerializeField]
    private float _movementSpeedLimit;
    [SerializeField]
    private float _rotateSpeed;
    [SerializeField]
    private float _rotateAngle;
    
    private Rigidbody _rigidbody;
    private Transform _transform;

    private CharacterMoveForwardState _moveForwardState;
    private CharacterRotateState _rotateRightState;
    private CharacterRotateState _rotateLeftState;
    private BaseCharacterMovingState _currentState;

    private void InitStates()
    {
        _moveForwardState = new CharacterMoveForwardState(_transform, _rigidbody, _movementSpeed, _movementSpeedLimit);
        _rotateRightState = new CharacterRotateState(_transform, _rotateSpeed);
        _rotateLeftState = new CharacterRotateState(_transform, _rotateSpeed, -1);
    }
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
        InitStates();
        ActivateMoveForwardState();
    }

    private void FixedUpdate()
    {
        _currentState.DoAction();
    }

    public void ActivateRotateState(int direction)
    {
        _currentState = direction == 1 ? _rotateRightState : _rotateLeftState;
        StartCoroutine(WaitRotation());
    }

    private IEnumerator WaitRotation()
    {
        Quaternion startRotation = _transform.rotation;
        Quaternion currentRotation = startRotation;
        while (Quaternion.Angle(startRotation,currentRotation) < _rotateAngle -_rotateSpeed)
        {
            currentRotation = _transform.rotation;
            yield return new WaitForFixedUpdate();
        }
        ActivateMoveForwardState();
    }

    private void ActivateMoveForwardState()
    {
        _currentState = _moveForwardState;
    }
}
