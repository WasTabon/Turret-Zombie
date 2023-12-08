using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private int _capacity;
    [SerializeField] private Transform _container;
    
    private PoolMono<Enemy> _pool;

    private void Start()
    {
        _pool = new PoolMono<Enemy>(_prefab, _autoExpand, _container);
        _pool.CreatePool(_capacity);
    }

    private void Update()
    {
        
    }

    private void Spawn()
    {
        var enemy =  _pool.GetFreeElement();
    }
}
