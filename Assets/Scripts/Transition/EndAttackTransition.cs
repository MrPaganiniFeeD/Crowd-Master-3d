using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAttackTransition : Transition
{
    [SerializeField] private AttackState _attackState;

    private void OnEnable()
    {
        _attackState.AbilityEnded += Transit;
    }
    private void OnDisable()
    {
        _attackState.AbilityEnded -= Transit;
    }

    public override void Transit()
    {
        StateMachine.SwitchState<IdleState>();
    }
}
