using UnityEngine;

public class ClickOnArrowChecker : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _raycastHit;
    private Camera _mainCamera;

    private const int MouseButtonId = 0;

    private void Start()
    {
        _mainCamera = Camera.main;
    }
    private void Update()
    {
        if (!Input.GetMouseButtonDown(MouseButtonId)) return;
        ClickOnArrow();
    }

    private void ClickOnArrow()
    {
        _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(_ray, out _raycastHit)) return;
        if (_raycastHit.collider.TryGetComponent(out ArrowChanger arrowChanger))
        {
            arrowChanger.RotateArrow();
        }

    }
}
