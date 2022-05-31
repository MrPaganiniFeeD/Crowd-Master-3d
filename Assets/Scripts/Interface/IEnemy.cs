using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IEnemy 
{
    event UnityAction<int> HealthChange;
    event UnityAction<IEnemy> Died;
    void TakeDamage(int damage);
}
