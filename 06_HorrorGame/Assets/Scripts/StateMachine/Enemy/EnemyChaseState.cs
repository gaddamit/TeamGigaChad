using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public EnemyChaseState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log($"{_stateMachine.name} Entering Chase State");
        _stateMachine.Agent.speed = _stateMachine.chaseSpeed;
        _stateMachine.OnPlayerDetected += ChasePlayer;
    }

    public override void UpdateState()
    {
        
        // Checks if the player is in the radius given, if not return to idle state
        if (!IsInRadius(_stateMachine.Target, 10f))
        {
            _stateMachine.Target = null;
            _stateMachine.ChangeState(_stateMachine.IdleState);
        }
    }

    public override void ExitState()
    {
        _stateMachine.OnPlayerDetected -= ChasePlayer;
    }

    void ChasePlayer()
    {
        SetTarget(_stateMachine.Target);
    }
}
