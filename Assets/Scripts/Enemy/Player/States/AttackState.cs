using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackState : BaseState
{
    [SerializeField] private AbilitySwitcher _abilitySwitcher;

    private Ability _currentAbility;

    public event UnityAction<IDamagable> CollisionDetected;
    public event UnityAction AbilityEnded;

    public override void Enter()
    {
        enabled = true;


        _currentAbility = _abilitySwitcher.GetAbility();

        _currentAbility.AbilityEnded += OnAbilityEnded;
        _currentAbility.UseAbility(this);
    }
    private void OnEnable()
    {
        SelfAnimation.SetTrigger("Attack");
    }
    public override void Exit()
    {
        enabled = false;
        //Debug.Log("Exit Attack state");
    }

    private void OnDisable()
    {
        _currentAbility.AbilityEnded -= OnAbilityEnded;
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamagable damagable))
            CollisionDetected?.Invoke(damagable);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamagable damagable))
            CollisionDetected?.Invoke(damagable);
    }

    private void OnAbilityEnded()
    {
        AbilityEnded?.Invoke();
    }
}
