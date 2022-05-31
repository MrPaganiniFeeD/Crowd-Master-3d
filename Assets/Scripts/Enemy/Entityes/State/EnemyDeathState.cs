using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(BoxCollider))]
public class EnemyDeathState : BaseState, IDeathState
{
    private BoxCollider _boxCollider;

    private const string _nameDeadAnimation = "Dead";

    private Coroutine _coroutine;

    public override void Enter()
    {
        _boxCollider = GetComponent<BoxCollider>();
        enabled = true;
        Dead();

    }

    public override void Exit()
    {
        StopCoroutine(_coroutine);
    }
    public void Dead()
    {
        SelfAnimation.SetTrigger(_nameDeadAnimation);

        _coroutine = StartCoroutine(DestroyObject());
    }
    private IEnumerator DestroyObject()
    {
        _boxCollider.isTrigger = true;
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
        Exit();
    }
}
