using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    [SerializeField]
    private Transform objectToFollow;

    [SerializeField] private float speed;

    private Vector3 _currentVelocity;
    
    private void Update()
    {
        Follow();    
    }


    private void Follow()
    {
        var targetPosition = transform.position;
        targetPosition.y = Mathf.Max(transform.position.y, objectToFollow.position.y);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, speed * Time.deltaTime);
    }
}
