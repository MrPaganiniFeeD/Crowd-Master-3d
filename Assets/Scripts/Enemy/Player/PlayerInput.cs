using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public event UnityAction<Vector3> DirectionChanged;
    public event UnityAction PointerUp;

    private Vector3 _tapPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _tapPosition = Input.mousePosition;

        if (Input.GetMouseButton(0))
            DirectionChanged?.Invoke(Input.mousePosition - _tapPosition);

        if (Input.GetMouseButtonUp(0))
            PointerUp?.Invoke();
    }
}
