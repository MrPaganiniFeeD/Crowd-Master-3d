using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransition : Transition
{

    private void Update()
    {
        Transit();   
    }
    public override void Transit()
    {
        if (Input.GetMouseButtonDown(0))
            StateMachine.SwitchState<MoveState>();
    }
}
