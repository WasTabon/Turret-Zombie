using UnityEngine;
using Zenject;

public class EndGamePanelController : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _DieText;
    [SerializeField] private GameObject _WonText;

    [Inject] private LevelEndController _levelEndController;
    
    private Car _car;

    private void Start()
    {
        _car = GameObject.FindWithTag("Player").GetComponent<Car>();

        _car.dead += Die;
        _levelEndController.won += Won;
    }

    private void Die()
    {
        _panel.SetActive(true);
        _DieText.SetActive(true);
    }

    private void Won()
    {
        _panel.SetActive(true);
        _WonText.SetActive(true);
    }
}
