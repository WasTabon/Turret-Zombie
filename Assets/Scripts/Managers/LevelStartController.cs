using System;
using UnityEngine;
using Zenject;

public class LevelStartController : MonoBehaviour
{
    [SerializeField] private Animator _cameraAnimator;
    public event Action startGame;
    
    [HideInInspector] public bool playerMoving;
    [HideInInspector] public bool enemySpawning;

    [Inject] private InputManager _inputManager;

    private void Start()
    {
        _inputManager.clickOnScreen += StartGame;
    }

    private void StartGame()
    {
        float animLenght = 1f;
        _cameraAnimator.SetTrigger("StartGame");
        Invoke("InvokeEvent", animLenght);
    }

    private void InvokeEvent()
    {
        Destroy(_cameraAnimator);
        startGame?.Invoke();
    }
}
