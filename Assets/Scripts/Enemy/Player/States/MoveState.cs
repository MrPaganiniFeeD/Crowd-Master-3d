using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : BaseState
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private StaminaAccumulator _staminaAccumulator;

    private void OnEnable()
    {
        _playerInput.DirectionChanged += OnDirectionChanged;
        _staminaAccumulator.StartAccumalate();
    }
    private void OnDisable()
    {
        _playerInput.DirectionChanged -= OnDirectionChanged;
    }

    public override void Enter()
    {
        enabled = true;
    }

    public override void Exit()
    {
        enabled = false;
    }
    private void OnDirectionChanged(Vector3 direction)
    {
        MoveBehaviour.Move(direction);
    }
}
