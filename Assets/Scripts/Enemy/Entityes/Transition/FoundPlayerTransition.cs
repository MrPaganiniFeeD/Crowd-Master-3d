using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundPlayerTransition : Transition
{
    [SerializeField] private float _foundDistance;
    [SerializeField] private Transform _enemyTransform;
   

    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (Vector3.Distance(_player.transform.position, _enemyTransform.position) < _foundDistance)
        {
            Transit();
        }

    }
    public override void Transit()
    {
        StateMachine.SwitchState<FoundPlayerState, IdleState>();
    }
}
