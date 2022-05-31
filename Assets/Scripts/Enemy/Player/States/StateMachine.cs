using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour, IStationStateSwitcher
{
    private List<BaseState> _allStates;
    private BaseState _currentState;


    private void Start()
    {

        _allStates = InitStates();

        _currentState = _allStates[0];
        _currentState.Enter();

    }
    private void ChangeState<T>() where T : BaseState
    {
        if (_currentState is IDeathState)
            return;
       

        if (_currentState is T)
            return;

        var newState = _allStates.FirstOrDefault(s => s is T);
        _currentState.Exit();
        newState.Enter();
        _currentState = newState;
    }
    public void SwitchState<T>() where T : BaseState
    {
        ChangeState<T>();
    }
    public void SwitchState<T, S>() where T : BaseState where S : BaseState
    {
        if (_currentState is S)
        {
            ChangeState<T>();
        }
    }

    protected abstract List<BaseState> InitStates();

}
