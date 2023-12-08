using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamageable
{
    [SerializeField] protected int healthToSet;

    protected HealthSystem _healthSystem;

    protected virtual void Start()
    {
        _healthSystem = new HealthSystem(healthToSet);
    }

    protected virtual void Update()
    {
        Move();
    }

    public void DealDamage(int damageAmount)
    {
        Damage(damageAmount);
    }

    protected virtual void Move()
    {
        
    }

    protected virtual void Damage(int damageAmount)
    {
        _healthSystem.Damage(damageAmount);
    }

    protected virtual void Death()
    {
        
    }
}
