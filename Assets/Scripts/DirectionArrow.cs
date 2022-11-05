using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DirectionArrow : MonoBehaviour
{
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out CharacterBehaviour characterBehaviour)) return;
        print(_direction);
        characterBehaviour.ActivateRotateState(_direction);
    }


}
