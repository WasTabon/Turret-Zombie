using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelStartController : MonoBehaviour
{
    [SerializeField] private Animator _cameraAnimator;
    public event Action startGame;
    public event Action endGame;
    
    [HideInInspector] public bool playerMoving;
    [HideInInspector] public bool enemySpawning;

    [Inject] private InputManager _inputManager;
    [Inject] private LevelEndController _levelEndController;
    
    private bool _canRestartGame;

    private Car _car;
    
    private void Start()
    {
        _car = GameObject.FindWithTag("Player").GetComponent<Car>();
        
        _inputManager.clickOnScreen += StartGame;
        _inputManager.clickOnScreen += RestartGame;

        _levelEndController.won += InvokeEventRestart;
        _car.dead += InvokeEventRestart;
    }

    private void StartGame()
    {
        if (_canRestartGame == false)
        {
            float animLenght = 1f;
            _cameraAnimator.SetTrigger("StartGame");
            Invoke("InvokeEventStart", animLenght);
        }
    }

    private void RestartGame()
    {
        if (_canRestartGame)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    
    private void InvokeEventStart()
    {
        Destroy(_cameraAnimator);
        startGame?.Invoke();
    }

    private void InvokeEventRestart()
    {
        _canRestartGame = true;
        endGame?.Invoke();
    }
}
