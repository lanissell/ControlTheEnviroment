using UnityEngine;

public class CharacterMoveForwardState: BaseCharacterMovingState
{
    private Vector3 _moveDirection;
    private readonly Rigidbody _characterRigidbody;
    private readonly float _speedLimit;

    public CharacterMoveForwardState(Transform characterTransform, Rigidbody characterRigidbody, float speed, float speedLimit) 
        : base(characterTransform, speed)
    {
        _characterRigidbody = characterRigidbody;
        _speedLimit = speedLimit;
    }

    public override void DoAction()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        var velocity = _characterRigidbody.velocity;
        if (velocity.magnitude > _speedLimit ) return;
        _moveDirection = CharacterTransform.forward;
        _characterRigidbody.AddForce(_moveDirection * (Speed * Time.fixedTime));
    }
    
}

