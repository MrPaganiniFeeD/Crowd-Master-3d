using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FoundPlayerState : BaseState
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private Player _player;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _player = FindObjectOfType<Player>();
        
    }

    private void Update()
    {
        _agent.SetDestination(_player.transform.position);
        _animator.SetFloat("Run", _agent.speed);

    }
    private void OnEnable()
    {
        _agent.enabled = true;
    }
    private void OnDisable()
    {
        _agent.enabled = false;
    }
    public override void Enter()
    {     
        enabled = true;
    }

    public override void Exit()
    {
        enabled = false;
        _animator.SetFloat("Run", 0);
    }
}
