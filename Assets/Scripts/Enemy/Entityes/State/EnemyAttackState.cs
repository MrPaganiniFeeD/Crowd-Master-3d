using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : BaseState
{

    private Coroutine _coroutine;


    public override void Enter()
    {
        enabled = true;
        _coroutine = StartCoroutine(AttackBehaviour.Attack(Player));
    }

    public override void Exit()
    {
        StopCoroutine(_coroutine);
        enabled = false;
    }
    private void Update()
    {
        
    }
}
