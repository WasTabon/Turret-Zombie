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
    [Inject] private BooletSpawner _booletSpawner;

    [SerializeField] private bool _canShoot;
    
    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        while (_canShoot)
        {
            Debug.Log("Shoot");
            _booletSpawner.Spawn(_shootPos, _turretTransform);
            
            transform.Translate(transform.forward * _repulsionSpeed * _repulsionDistance);
            yield return new WaitForSeconds(_repulsionDelay);
            transform.Translate(transform.forward * -1 * _repulsionSpeed * _repulsionDistance);
            
            yield return new WaitForSeconds(_shootDelay);
            Debug.Log("Shoot end");
        }
    }
    
}
