using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition : Transition
{
    private void Update()
    {
        Transit();
    }
    public override void Transit()
    {
        if (Input.GetMouseButtonUp(0))
            StateMachine.SwitchState<AttackState>();
    }
}
