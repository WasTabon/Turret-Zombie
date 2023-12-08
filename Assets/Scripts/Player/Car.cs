using System;
using System.Collections;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class Car : Character
{
    [SerializeField] private float _speed;
    [SerializeField] private float _shiftSpeed;
    [SerializeField] private float _shiftMagnitude;
    
    [SerializeField] private Color hitColor;
    [SerializeField] private GameObject _deathEffect;
    
    [SerializeField] private MeshRenderer _meshRenderer;
    
    [Inject] private LevelStartController _levelStartController;
    [Inject] private LevelEndController _levelEndController;
    
    private bool _isDeadFlag = false;
    private bool _canMove;

    public event Action dead;
    
    private Rigidbody _rigidbody;
    
    private Color _orignialColor;

    protected override void Start()
    {
        base.Start();
        _rigidbody = GetComponent<Rigidbody>();
        
        _orignialColor = _meshRenderer.material.color;

        _levelStartController.startGame += StartMovement;
        _levelEndController.won += Won;
    }

    protected override void Update()
    {
        base.Update();
        Death();
        Debug.Log($"Health - {_healthSystem.Health}");
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    protected override void Damage(int damageAmount)
    {
        base.Damage(damageAmount);
        Debug.Log("Damaged");
        StartCoroutine(HitChangeColor());
    }

    private void StartMovement()
    {
        _canMove = true;
    }
    
    protected override void Move()
    {
        if (_canMove)
        {
            Vector3 forwardMovement = transform.forward * _speed * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + forwardMovement);
        
            float _horizontalInput = Mathf.PingPong(Time.time * _shiftMagnitude, 2f) - 1f;
        
            Vector3 sideMovement = transform.right * _horizontalInput * _shiftSpeed * Time.deltaTime;
            Vector3 finalPosition = _rigidbody.position + sideMovement;
        
            _rigidbody.MovePosition(Vector3.Lerp(_rigidbody.position, finalPosition, 0.5f));
        }
    }
    
    protected override void Death()
    {
        if (_healthSystem.Health <= 0 && _isDeadFlag == false)
        {
            _isDeadFlag = true;
            Vector3 spawnPosition = transform.position; // Получаем позицию объекта
            Vector3 halfHeightOffset = new Vector3(0, transform.localScale.y * 0.5f, 0); // Определяем смещение на половину высоты объекта
            spawnPosition += halfHeightOffset; // Применяем смещение к позиции спавна
            Instantiate(_deathEffect, spawnPosition, Quaternion.identity);
            SetDeath();
            dead?.Invoke();
        }
    }
    private void SetDeath()
    {
        gameObject.SetActive(false);
    }

    private void Won()
    {
        _canMove = false;
    }
    
    private IEnumerator HitChangeColor()
    {
        float hitTime = 0.1f;
        _meshRenderer.material.color = hitColor;
        yield return new WaitForSeconds(hitTime);
        _meshRenderer.material.color = _orignialColor;
    }
}
