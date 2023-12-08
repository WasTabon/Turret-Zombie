using System;
using UnityEngine;

public class LevelEndController : MonoBehaviour
{
    public event Action won;
    
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            won?.Invoke();
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            won?.Invoke();
        }
    }
}