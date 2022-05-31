using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathState : BaseState, IDeathState
{

    private const string _nameAnimation = "Die";

    public event UnityAction Died;
    public override void Enter()
    {
        Dead();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void Dead()
    {
        SelfAnimation.SetTrigger(_nameAnimation);
        Died?.Invoke();
    }
     

}
