using UnityEngine;
public abstract class BaseCharacterMovingState
{
        protected readonly Transform CharacterTransform;
        protected readonly float Speed;

        protected BaseCharacterMovingState(Transform characterTransform, float speed)
        {
                CharacterTransform = characterTransform;
                Speed = speed;
        }

        public abstract void DoAction();
}