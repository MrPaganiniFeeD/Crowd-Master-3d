using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaAccumulator : MonoBehaviour
{
    [SerializeField] private float _accumulationTime;

    private float _staminaValue;

    public float Value => _staminaValue;
    public float AccumulationTime => _accumulationTime;

    public void StartAccumalate()
    {
        _staminaValue = 0;
    }
    private void Update()
    {
        _staminaValue += Time.deltaTime;  
    }

   


}
