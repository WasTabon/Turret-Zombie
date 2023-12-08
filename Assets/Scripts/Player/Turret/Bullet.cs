using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _destroyAfterSeconds;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private void Start()
    {
        Invoke("Disappear", _destroyAfterSeconds);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(transform.forward * _speed * Time.deltaTime);
    }

    

    private void Disappear()
    {
        gameObject.SetActive(false);
    }
}
