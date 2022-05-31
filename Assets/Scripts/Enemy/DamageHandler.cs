using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(HealthContainer))]
public abstract class DamageHandler : MonoBehaviour, IDamagable
{
    protected HealthContainer HealthContainer { get; private set; }
    protected IStationStateSwitcher Swicher { get; private set; }

    private void Awake()
    {
        HealthContainer = GetComponent<HealthContainer>();
        Swicher = GetComponent<IStationStateSwitcher>();
    }

    public virtual bool ApplyDamage(Rigidbody rigidbody, float force)
    {
        HealthContainer.TakeDamage((int)force);
        Transit();
        return true;
    }

    public abstract void Transit();


}
