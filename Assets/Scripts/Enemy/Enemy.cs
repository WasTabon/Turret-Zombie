using UnityEngine;

public class Enemy : Character
{
    private bool _seeCar;

    protected override void Start()
    {
        base.Start();
    }
    
    private void OnTriggerStay(Collider coll)
    {
        if (coll.TryGetComponent(out Car car))
        {
            _seeCar = true;
        }
    }
}
