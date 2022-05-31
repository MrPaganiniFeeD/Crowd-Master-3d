using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageState : BaseState
{
    [SerializeField] private int _decelerationForce;

    private const string _nameAnimation = "TakeDamage";

    public override void Enter()
    {
        enabled = true;
        SelfAnimation.SetTrigger(_nameAnimation);
        StartCoroutine(Deceleration());
    }
    public override void Exit()
    {
        enabled = false;
        StopCoroutine(Deceleration());
    }
    private void Update()
    {
        
    }
    private IEnumerator Deceleration()
    {
        SelfRigidbody.drag = _decelerationForce;
        yield return new WaitForSeconds(0.2f);
        SelfRigidbody.drag = 0;

    }
}
