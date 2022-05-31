using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageHandler : DamageHandler
{
    [SerializeField] private BrokenState _brokenState;

    public override bool ApplyDamage(Rigidbody rigidbody, float force)
    {
        base.ApplyDamage(rigidbody, force);
        _brokenState.ApplyDamage(rigidbody, force);

        return true;
    }
    public override void Transit()
    {
        Swicher.SwitchState<BrokenState>();
    }

}
