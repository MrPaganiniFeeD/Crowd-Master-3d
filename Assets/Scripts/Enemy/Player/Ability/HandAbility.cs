using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Hand Ability", menuName = "Player/Abilities/Hand", order = 51)]
public class HandAbility : Ability
{
    [SerializeField] private float _attackForce;
    [SerializeField] private float _usefulTime;

    private AttackState _state;
    private Coroutine _coroutine;

    public override event UnityAction AbilityEnded;


    public override void UseAbility(AttackState attackState)
    {
        if (_coroutine != null)
            Reset();

        _state = attackState;

        _coroutine = _state.StartCoroutine(Attack(_state));
        _state.CollisionDetected += OnPlayerCollision;
    }
    private IEnumerator Attack(AttackState state)
    {
        float time = _usefulTime;

        while(time > 0)
        {
            state.SelfRigidbody.velocity = state.SelfRigidbody.velocity.normalized * _attackForce;
            time -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Reset();
        AbilityEnded?.Invoke();
    }

    private void Reset()
    {
        _state.SelfRigidbody.velocity = Vector3.zero;
        _state.StopCoroutine(_coroutine);
        _coroutine = null;
        _state.CollisionDetected -= OnPlayerCollision;
    }

    private void OnPlayerCollision(IDamagable damagable)
    {
        if (damagable.ApplyDamage(_state.SelfRigidbody, _attackForce))
            return;

        _state.SelfRigidbody.velocity /= 2;
    }
}
