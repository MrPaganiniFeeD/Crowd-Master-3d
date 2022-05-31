using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathTransition : Transition
{
    [SerializeField] private HealthContainer _healthContainer;

    private void OnEnable()
    {
        _healthContainer.Died += OnDied;
    }
    private void OnDisable()
    {
        _healthContainer.Died -= OnDied;
    }

    private void OnDied()
    {
        Transit();
    }

    public override void Transit()
    {
        StateMachine.SwitchState<EnemyDeathState>();
    }

}
