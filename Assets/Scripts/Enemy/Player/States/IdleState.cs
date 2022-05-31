using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override void Enter()
    {
        enabled = true;

    }

    public override void Exit()
    {
        enabled = false;
    }
    private void Update()
    {
        
    }
}
