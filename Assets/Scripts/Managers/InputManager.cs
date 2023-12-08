using UnityEngine;

public class InputManager : MonoBehaviour
{
    [HideInInspector] public bool _isTouchingScreen;
    
    private Vector2 _touchPosition;

    public Vector2 TouchPosition
    {
        get => _touchPosition;
    }
    
    private Vector2 _touchPositionDelta;

    public Vector2 TouchPositionDelta
    {
        get => _touchPositionDelta;
    }
    
    private Vector2 lastMousePosition;

    private void Update()
    {
        if (Input.touchSupported)
            TouchMove();
        else
            MouseMove();
    }

    private void TouchMove()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                _isTouchingScreen = true;
                Vector2 touchPosition = touch.position;
                _touchPositionDelta += touch.deltaPosition;
                _touchPosition = touchPosition;
            }

            if (touch.phase == TouchPhase.Canceled)
            {
                _isTouchingScreen = false;
            }
        }
    }

    private void MouseMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        
        if (Input.GetMouseButton(0))
        {
            _isTouchingScreen = true;
            Vector2 currentMousePosition = Input.mousePosition;
            _touchPositionDelta = currentMousePosition - lastMousePosition;
            _touchPosition = currentMousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isTouchingScreen = false;
        }
    }
}
