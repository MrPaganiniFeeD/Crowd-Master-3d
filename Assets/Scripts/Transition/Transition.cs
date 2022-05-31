using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private StateMachine _stateMachine;
    public StateMachine StateMachine => _stateMachine;

    public abstract void Transit();
}
