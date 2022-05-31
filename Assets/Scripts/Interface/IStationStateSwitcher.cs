using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStationStateSwitcher
{
    public void SwitchState<T>() where T : BaseState;
    public void SwitchState<T, S>() where T : BaseState where S : BaseState;
}
