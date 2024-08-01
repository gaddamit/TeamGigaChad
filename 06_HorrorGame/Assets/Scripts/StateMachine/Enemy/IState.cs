using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void Enter();
    public void UpdateState();
    public void PhysicsUpdate();
    public void ExitState();
}
