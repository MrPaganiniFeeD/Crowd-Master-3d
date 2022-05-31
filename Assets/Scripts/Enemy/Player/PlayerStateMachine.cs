using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerStateMachine : StateMachine
{
    private List<BaseState> _playerState;

    protected override List<BaseState> InitStates()
    {
        return _playerState = new List<BaseState>
        {
            GetComponent<IdleState>(),
            GetComponent<AttackState>(),
            GetComponent<MoveState>(),
            GetComponent<TakeDamageState>(),
            GetComponent<DeathState>()
        };
    }
}
