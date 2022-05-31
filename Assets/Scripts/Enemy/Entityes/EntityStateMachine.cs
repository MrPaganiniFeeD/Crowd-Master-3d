using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Entity))]
public class EntityStateMachine : StateMachine
{
    private List<BaseState> _entityStates;
    protected override List<BaseState> InitStates()
    {
        return _entityStates = new List<BaseState>
        {
            GetComponent<IdleState>(),
            GetComponent<FoundPlayerState>(),
            GetComponent<BrokenState>(),
            GetComponent<EnemyAttackState>(),
            GetComponent<EnemyDeathState>()
        };
        
    }
    private void Update()
    {

    }
}
