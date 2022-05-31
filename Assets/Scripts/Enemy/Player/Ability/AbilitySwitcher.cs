using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySwitcher : MonoBehaviour
{
    [SerializeField] private Ability _defaultAbility;
    [SerializeField] private Ability _ultimate;

    [SerializeField] private StaminaAccumulator _stamina;

    public Ability GetAbility()
    {
        if (_stamina.Value > _stamina.AccumulationTime)
            return _ultimate;

        return _defaultAbility;
    }



}
