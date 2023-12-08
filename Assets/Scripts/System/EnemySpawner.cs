using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [Header("POOL")]
    [SerializeField] private Enemy _prefab;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private int _capacity;
    [SerializeField] private Transform _container;

    [Header("SPAWN SETTINGS")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _distanceFromPlayerToSpawn;
    [SerializeField] private float _spawnDelay = 0.3f;

    [Inject] private LevelStartController _levelStartController;
    
    private PoolMono<Enemy> _pool;
    private float _timer;

    private void Start()
    {
        _pool = new PoolMono<Enemy>(_prefab, _autoExpand, _container);
        _pool.CreatePool(_capacity);
        _timer = _spawnDelay;

        _levelStartController.startGame += StartSpawning;
    }

    private void Update()
    {
        
    }

    private void StartSpawning()
    {
        InvokeRepeating("Spawn", 1f, _spawnDelay);
    }
    
    private void Spawn()
    {
        var enemy = _pool.GetFreeElement();
        if (enemy != null)
        {
            // Генерируем случайную позицию по оси X в заданном диапазоне
            float randomX = Random.Range(-10f, 10f); // Здесь можно указать нужный диапазон значений по оси X
    
            // Располагаем врага на расстоянии 200f от игрока, с случайной позицией по X
            Vector3 spawnPosition = _playerTransform.position + new Vector3(randomX, 4f, _distanceFromPlayerToSpawn);
            enemy.transform.position = spawnPosition;
            enemy.gameObject.SetActive(true);
        }
    }
}