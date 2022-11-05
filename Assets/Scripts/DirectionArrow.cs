using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DirectionArrow : MonoBehaviour
{
    [SerializeField]
    private float _rotationDelay;
    [SerializeField]
    private float _rotationAngle;
    private bool _canRotateCharacter;
    
    private enum Directions
    {
        Right = 1,
        Left = -1
    }

    [SerializeField] 
    private Directions _directions = Directions.Right;

    private int _direction;
    
    private void Start()
    {
        _direction = (int)_directions;
        _canRotateCharacter = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_canRotateCharacter) return;
        if (!other.TryGetComponent(out CharacterBehaviour characterBehaviour)) return;
        _canRotateCharacter = false;
        characterBehaviour.ActivateRotateState(_direction, _rotationAngle);
        StartCoroutine(RotationDelay());
    }

    private IEnumerator RotationDelay()
    {
        yield return new WaitForSeconds(_rotationDelay);
        _canRotateCharacter = true;
    }


}
