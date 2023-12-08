using System.Collections;
using UnityEngine;
using Zenject;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform _shootPos;
    [SerializeField] private Transform _turretTransform;
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _repulsionDistance;
    [SerializeField] private float _repulsionSpeed;
    [SerializeField] private float _repulsionDelay;

    [Inject] private LevelStartController _levelStartController;
    public BooletSpawner _BulletSpawner;

    [SerializeField] private bool _canShoot = true;
    
    private void Start()
    {
        _levelStartController.startGame += StartShooting;
        _levelStartController.endGame += StopShooting;

        _canShoot = true;
    }

    private void StartShooting()
    {
        StartCoroutine(Shooting());
    }

    private void StopShooting()
    {
        _canShoot = false;
    }
    
    private IEnumerator Shooting()
    {
        while (_canShoot)
        {
            _BulletSpawner.Spawn(_shootPos, _turretTransform);
            
            transform.Translate(transform.forward * _repulsionSpeed * _repulsionDistance);
            yield return new WaitForSeconds(_repulsionDelay);
            transform.Translate(transform.forward * -1 * _repulsionSpeed * _repulsionDistance);
            
            yield return new WaitForSeconds(_shootDelay);
        }
    }
    
}
