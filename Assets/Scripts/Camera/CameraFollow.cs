using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [Range(0.01f, 1.0f)]
    private float _SmoothFactor = 0.5f;

    private Vector3 _cameraOffset;


    private void Start()
    {
        _cameraOffset = transform.position - _player.position;
    }
    private void LateUpdate()
    {
        Vector3 newPos = _player.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, _SmoothFactor);
    }


}

