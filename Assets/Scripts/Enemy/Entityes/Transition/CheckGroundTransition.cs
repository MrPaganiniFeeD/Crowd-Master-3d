using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGroundTransition : Transition
{
    [SerializeField] private Rigidbody _rigidbody;

    private void FixedUpdate()
    {
        CheckGround();
    }
    private void CheckGround()
    {
        Ray ray = new Ray(transform.position + Vector3.up, Vector3.down);
        if (Physics.Raycast(ray, 5f) == false)
            Drop();
    }

    private void Drop()
    {
        Transit();
        _rigidbody.constraints = RigidbodyConstraints.None;
    }

    public override void Transit()
    {
        StateMachine.SwitchState<EnemyDeathState>();
    }
}
