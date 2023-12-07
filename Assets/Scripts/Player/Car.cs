using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class Car : Character
{
    [SerializeField] private float _speed;
    [SerializeField] private float _shiftSpeed;
    [SerializeField] private float _shiftMagnitude;


    [Inject] private LevelStartController _levelStartController;
    
    private Rigidbody _rigidbody;

    protected override void Start()
    {
        base.Start();

        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected override void Move()
    {
        
            Vector3 forwardMovement = transform.forward * _speed * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + forwardMovement);
            
            float _horizontalInput = Mathf.PingPong(Time.time * _shiftMagnitude, 2f) - 1f;
            
            Vector3 sideMovement = transform.right * _horizontalInput * _shiftSpeed * Time.deltaTime;
            Vector3 finalPosition = _rigidbody.position + sideMovement;
            
            _rigidbody.MovePosition(Vector3.Lerp(_rigidbody.position, finalPosition, 0.5f));

    }
}
