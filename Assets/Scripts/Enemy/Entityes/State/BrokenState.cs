using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenState : BaseState
{
    [SerializeField] private float _decelerationForce;

    private const string _nameAnimation = "TakeDamage";

    private Coroutine _coroutine;

    public override void Enter()
    {
        enabled = true;
        SelfAnimation.SetTrigger(_nameAnimation);
    }
    public override void Exit()
    {
        enabled = false;
        StopCoroutine(_coroutine);
    }
    public void ApplyDamage(Rigidbody attachedBody, float force)
    {
        if (enabled != true) return;
        
        Vector3 direction = (transform.position - attachedBody.position);
        direction.y = 0;
        SelfRigidbody.AddForce(direction.normalized * force *2, ForceMode.Impulse);
        _coroutine = StartCoroutine(Deceleration());
    }
    private IEnumerator Deceleration()
    {
        yield return new WaitForSeconds(0.1f);
        SelfRigidbody.drag = _decelerationForce;
        Debug.Log("Ex");
        yield return new WaitForSeconds(0.4f);
        SelfRigidbody.drag = 0;

    }
}
