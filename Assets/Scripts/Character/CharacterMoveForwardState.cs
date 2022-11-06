using UnityEngine;

public class CharacterMoveForwardState: BaseCharacterMovingState
{
    private Vector3 _moveDirection;
    private readonly Rigidbody _characterRigidbody;

    public CharacterMoveForwardState(Transform characterTransform, Rigidbody characterRigidbody, float speed) 
        : base(characterTransform, speed)
    {
        _characterRigidbody = characterRigidbody;
    }

    public override void DoAction()
    {
        MoveForward();  
    }

    private void MoveForward()
    {
        _moveDirection = CharacterTransform.forward;
        _characterRigidbody.AddForce(_moveDirection * (Speed * Time.fixedDeltaTime), ForceMode.VelocityChange);
    }
}

