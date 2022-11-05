using UnityEngine;

public class CharacterRotateState: BaseCharacterMovingState
{
    private readonly float _rotationSide;

    public CharacterRotateState(Transform characterTransform, float speed, float rotationSide = 1) 
        : base(characterTransform, speed)
    {
        _rotationSide = rotationSide;
    }
    
    public override void DoAction()
    {
        CharacterTransform.Rotate(CharacterTransform.up * (_rotationSide * Speed), Space.World);
    }
 
}