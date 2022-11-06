using System.Collections;
using Character;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DirectionArrow : MonoBehaviour
{
    public CharacterRotateAngles Angle = CharacterRotateAngles.Right;
    
    [SerializeField]
    private float _characterRotationDelay;
    private bool _canRotateCharacter;
    
    private void Start()
    {
        _canRotateCharacter = true;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (!_canRotateCharacter) return;
        if (!other.TryGetComponent(out CharacterBehaviour characterBehaviour)) return;
        _canRotateCharacter = false;
        characterBehaviour.ActivateRotateState((int)Angle);
        StartCoroutine(CharacterRotationDelay());
    }

    private IEnumerator CharacterRotationDelay()
    {
        yield return new WaitForSeconds(_characterRotationDelay);
        _canRotateCharacter = true;
    }


}
