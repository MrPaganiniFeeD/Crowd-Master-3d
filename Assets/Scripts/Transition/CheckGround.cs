using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CheckGround : MonoBehaviour
{
    [SerializeField] private StateMachine _stateMachine;
    private Rigidbody _rigidbody;

    private Ray _ray;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Check();
    }
    private void Check()
    {
        _ray = new Ray(transform.position + Vector3.up, Vector3.down);
        if (Physics.Raycast(_ray, 5f) == false)
            Drop();
    }
    private void Drop()
    {
        _rigidbody.constraints = RigidbodyConstraints.None;
        _stateMachine.SwitchState<DeathState>();
    }

}
