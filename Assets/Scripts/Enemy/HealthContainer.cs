using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthContainer : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction ApplyDamage;
    public event UnityAction Died;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        CheckHealth();
        ApplyDamage?.Invoke();

    }
    private void CheckHealth()
    {
        if (_health <= 0)
            Died?.Invoke();
    }
}
