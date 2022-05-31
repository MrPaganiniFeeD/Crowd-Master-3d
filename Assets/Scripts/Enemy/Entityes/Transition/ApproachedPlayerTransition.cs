using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachedPlayerTransition : Transition
{
    [SerializeField] private float _foundDistance;
    [SerializeField] private float _attackDistance;
    [SerializeField] private Transform _enemyTransform;

    private float offset = 0.5f;

    private Player _player;

    private float _distance;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void LateUpdate()
    {
        _distance = Vector3.Distance(_player.transform.position, _enemyTransform.position);

        if (_distance < _attackDistance)
        {
            Transit();
        }
        else if(_distance > _attackDistance + offset && _distance <= _foundDistance)
        {
            StateMachine.SwitchState<FoundPlayerState>();
        }

    }
    public override void Transit()
    {
        StateMachine.SwitchState<EnemyAttackState>();
    }
}
