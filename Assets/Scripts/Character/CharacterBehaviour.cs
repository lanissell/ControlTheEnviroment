using System.Collections;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float _movementSpeed;
        [SerializeField]
        private float _rotateSpeed;
        [SerializeField]
        private Rigidbody _rigidbody;
        private Transform _transform;

        private CharacterMoveForwardState _moveForwardState;
        private CharacterRotateState _rotateRightState;
        private CharacterRotateState _rotateLeftState;
        private BaseCharacterMovingState _currentState;

        private void InitStates()
        {
            _moveForwardState = new CharacterMoveForwardState(_transform, _rigidbody, _movementSpeed);
            _rotateRightState = new CharacterRotateState(_transform, _rotateSpeed);
            _rotateLeftState = new CharacterRotateState(_transform, _rotateSpeed, -1);
        }
    
        private void Start()
        {
            if (_rigidbody == null)
                _rigidbody = GetComponent<Rigidbody>();
            _transform = transform;
            InitStates();
            ActivateMoveForwardState();
        }

        private void FixedUpdate()
        {
            _currentState.DoAction();
        }

        public void ActivateRotateState(float angle)
        {
            _currentState = angle > 0 ? _rotateRightState : _rotateLeftState;
            StartCoroutine(WaitRotation(angle));
        }

        private IEnumerator WaitRotation(float rotateAngle)
        {   
            Quaternion startRotation = _transform.rotation;
            Quaternion currentRotation = startRotation;
            while (Mathf.Abs(rotateAngle) - Mathf.Round(Quaternion.Angle(startRotation,currentRotation)) != 0)
            {
                currentRotation = _transform.rotation;
                yield return new WaitForFixedUpdate();
            }
            _transform.rotation = currentRotation;
            ActivateMoveForwardState();
        }

        private void ActivateMoveForwardState()
        {
            _currentState = _moveForwardState;
        }
    }
}
