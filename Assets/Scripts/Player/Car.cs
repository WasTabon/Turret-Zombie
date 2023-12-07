using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Car : Character
{
    [SerializeField] private float _speed;
    [SerializeField] private float _shift;
    
    private Rigidbody _rigidbody;
    
    protected override void Start()
    {
        base.Start();

        _rigidbody = GetComponent<Rigidbody>();
    }

    protected override void Move()
    {
        
    }
}
