using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float offset;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        
        Vector3 targetPosition = new Vector3(currentPosition.x, currentPosition.y, player.position.z - offset);

        transform.position = targetPosition;
    }
}
