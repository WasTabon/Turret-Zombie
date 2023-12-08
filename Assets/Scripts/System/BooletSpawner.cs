using UnityEngine;

public class BooletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private int _capacity;
    [SerializeField] private Transform _container;
    
    private PoolMono<Bullet> _pool;

    private void Start()
    {
        _pool = new PoolMono<Bullet>(_prefab, _autoExpand, _container);
        _pool.CreatePool(_capacity);
    }

    private void Update()
    {
        
    }
    
    public void Spawn(Transform shootTransform, Transform rotationTransform)
    {
        Debug.Log("Spawn called");
        var bullet =  _pool.GetFreeElement();
        Debug.Log("Free element");
        if (bullet != null)
        {
            Debug.Log("Got bullet");
            bullet.transform.position = shootTransform.position;
            Quaternion rotateDir = rotationTransform.rotation;
            bullet.transform.rotation = rotateDir;
        }
        else
        {
            Debug.LogError("Bullet was null. Pool might be empty or initialization issue.");
        }
    }
}
