using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : IState
{
    protected EnemyStateMachine _stateMachine;
    
    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    
    public void Enter() { throw new System.NotImplementedException(); }

    public void UpdateState() { throw new System.NotImplementedException(); }

    public void PhysicsUpdate() { throw new System.NotImplementedException(); }

    public void ExitState() { throw new System.NotImplementedException(); }
}
