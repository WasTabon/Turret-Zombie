using System;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    
}
