using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    private IDamagable _damagable;
    private void Awake()
    {
        _damagable = GetComponent<IDamagable>();
    }

    public void ApplyDamage(Rigidbody rigidbody , float force)
    {
        _damagable.ApplyDamage(rigidbody, force);
    }
}
