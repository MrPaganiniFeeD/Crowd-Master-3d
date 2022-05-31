using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour, IMovable
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedRatio;

    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        _animator.SetFloat("Run", _rigidbody.velocity.magnitude / _maxSpeed);
    }

    public void Move(Vector3 direction)
    {
        _rigidbody.velocity = new Vector3(direction.x, 0, direction.y) * _speedRatio;

        if (_rigidbody.velocity.magnitude > _maxSpeed)
            _rigidbody.velocity *= _maxSpeed / _rigidbody.velocity.magnitude;

        if (_rigidbody.velocity.magnitude != 0)
            _rigidbody.MoveRotation(Quaternion.LookRotation(_rigidbody.velocity, Vector3.up));



    }
}
