using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VerticalVelocityLimit : MonoBehaviour
{
    [SerializeField]
    private float _maxVelocity;
    private Rigidbody _rigidbody;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ClampVerticalVelocity(_rigidbody.velocity);
    }

    private void ClampVerticalVelocity(Vector3 velocity)
    {
        if (_rigidbody.velocity.sqrMagnitude > _maxVelocity)
        {
            var newVelocity = Vector3.ClampMagnitude(_rigidbody.velocity, _maxVelocity);
            float x = newVelocity.x;
            float z = newVelocity.z;
            _rigidbody.velocity = new Vector3(x, velocity.y, z);
        }
    }
}
