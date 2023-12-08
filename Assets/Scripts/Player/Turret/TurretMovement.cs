using UnityEngine;
using Zenject;

public class TurretMovement : MonoBehaviour
{
    [SerializeField] private float _inputResist;
    [SerializeField] private float _maxRotationAngle = 90f;

    [Inject] private InputManager _inputManager;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        Rotate();
    }
    
    private void Rotate()
    {
        if (_inputManager._isTouchingScreen)
        {
            float z = (_inputManager.TouchPositionDelta.x) * _inputResist * Time.deltaTime;
            transform.Rotate(0f, 0f, z);
        }
    }
}
