using System.Collections;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] protected Color hitColor;

    private bool _seeCar;

    private SkinnedMeshRenderer _skinnedMeshRenderer;
    private Color _orignialColor;
    
    protected override void Start()
    {
        base.Start();
        _skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();

        _orignialColor = _skinnedMeshRenderer.material.color;
    }
    
    protected override void Move()
    {
        
    }

    protected override void Damage(int damageAmount)
    {
        base.Damage(damageAmount);
        Debug.Log("Damaged");
        StartCoroutine(HitChangeColor());
    }

    private void OnTriggerStay(Collider coll)
    {
        if (coll.TryGetComponent(out Car car))
        {
            _seeCar = true;
        }
    }
    private IEnumerator HitChangeColor()
    {
        Debug.Log("Coroutine Color");
        float hitTime = 0.2f;
        _skinnedMeshRenderer.material.color = hitColor;
        yield return new WaitForSeconds(hitTime);
        _skinnedMeshRenderer.material.color = _orignialColor;
    }
}
