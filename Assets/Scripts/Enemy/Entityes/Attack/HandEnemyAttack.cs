using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandEnemyAttack : MonoBehaviour, IAttack
{
    [SerializeField] private float _force;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _attackRecharge;

    private const string _nameAnimation = "HandAttack";

    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    public IEnumerator Attack(Player player)
    {
        while (true) 
        {
            _animator.SetTrigger(_nameAnimation);
            yield return new WaitForSeconds(_attackDelay);
            player.ApplyDamage(_rigidbody, _force);
            yield return new WaitForSeconds(_attackRecharge);
        }
    }

}
