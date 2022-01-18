using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerTarget;

    [Range(0, 1)]
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector3 _offset;

    private void FixedUpdate()
    {
        Vector3 desiredPos = _playerTarget.position + _offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;
        
        transform.LookAt(_playerTarget);
    }
}
