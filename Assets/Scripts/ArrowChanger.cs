using UnityEngine;

[RequireComponent(typeof(DirectionArrow))]
public class ArrowChanger: MonoBehaviour
{
    private DirectionArrow _arrow;
    private Transform _transform;   
    private void Start()
    {
        _arrow = GetComponent<DirectionArrow>();
        _transform = transform;
    }

    public void RotateArrow()
    {
        switch (_arrow.Angle)
        {
            case CharacterRotateAngles.Right:
                _arrow.Angle = CharacterRotateAngles.Left;
                _transform.Rotate(0,0,180);
                return;
            case CharacterRotateAngles.Left:
                _arrow.Angle = CharacterRotateAngles.Around;
                break;
            case CharacterRotateAngles.Around:
                _arrow.Angle = CharacterRotateAngles.Right;
                break;
        }
        _transform.Rotate(0,0,90);
    }

}