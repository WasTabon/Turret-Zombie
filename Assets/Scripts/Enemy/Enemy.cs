using System;
using System.Collections;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float speed;
    [SerializeField] private int _damage;
    [SerializeField] private Color hitColor;
    [SerializeField] private GameObject _deathEffect;

    private bool _seeCar;

    private Transform _carTransform;
    
    private Animator _animator;
    
    private SkinnedMeshRenderer _skinnedMeshRenderer;
    private Color _orignialColor;

    private bool _isDeadFlag = false;

    private void OnEnable()
    {
        if (_isDeadFlag)
        {
            _healthSystem.Heal(100);
            _seeCar = false;
            _isDeadFlag = false;
            _animator.SetTrigger("Alive");
        }
    }

    protected override void Start()
    {
        base.Start();
        _skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        _carTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        
        _orignialColor = _skinnedMeshRenderer.material.color;
    }

    protected override void Update()
    {
        base.Update();
        Death();
    }

    protected override void Move()
    {
        if (_seeCar && _isDeadFlag == false)
        {
            _animator.SetTrigger("GoToCar");
            Vector3 direction = _carTransform.position - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);

            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }

    protected override void Damage(int damageAmount)
    {
        if (_isDeadFlag == false)
        {
            base.Damage(damageAmount);
            Debug.Log("Damaged");
            StartCoroutine(HitChangeColor());
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            IDamageable hit = coll.gameObject.GetComponent<IDamageable>();
            if (hit != null && _isDeadFlag == false)
            {
                hit.DealDamage(_damage);
                _healthSystem.Damage(100);
            }
        }
    }

    private void OnTriggerStay(Collider coll)
    {
        if (coll.TryGetComponent(out Car car))
        {
            _seeCar = true;
        }
    }

    protected override void Death()
    {
        if (_healthSystem.Health <= 0 && _isDeadFlag == false)
        {
            _isDeadFlag = true;
            Vector3 spawnPosition = transform.position;
            Vector3 halfHeightOffset = new Vector3(0, transform.localScale.y * 0.5f, 0);
            spawnPosition += halfHeightOffset;
            _animator.SetTrigger("Die");
            Instantiate(_deathEffect, spawnPosition, Quaternion.identity);
            Invoke("SetDeath", 1f);
        }
    }

    private void SetDeath()
    {
        gameObject.SetActive(false);
    }
    
    private IEnumerator HitChangeColor()
    {
        float hitTime = 0.1f;
        _skinnedMeshRenderer.material.color = hitColor;
        yield return new WaitForSeconds(hitTime);
        _skinnedMeshRenderer.material.color = _orignialColor;
    }
}
