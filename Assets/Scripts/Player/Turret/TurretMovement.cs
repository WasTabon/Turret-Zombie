using UnityEngine;
using Zenject;

public class TurretMovement : MonoBehaviour
{
    [SerializeField] private float _inputResist;
    [SerializeField] private float _maxRotationAngle = 90f;

    [Inject] private InputManager _inputManager;
    [Inject] private LevelStartController _levelStartController;

    private bool _canMove;
    
    private void Start()
    {
        _levelStartController.startGame += StartRotating;
    }

    private void Update()
    {
        Rotate();
    }

    private void StartRotating()
    {
        _canMove = true;
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
