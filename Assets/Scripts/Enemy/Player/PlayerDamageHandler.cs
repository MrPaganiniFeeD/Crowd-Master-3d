using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler : DamageHandler
{
    [SerializeField] private TakeDamageState _takeDamageState;

    public override bool ApplyDamage(Rigidbody rigidbody, float force)
    {
        base.ApplyDamage(rigidbody, force);
        return true;
    }
    public override void Transit()
    {
        Swicher.SwitchState<TakeDamageState>();
    }
}
