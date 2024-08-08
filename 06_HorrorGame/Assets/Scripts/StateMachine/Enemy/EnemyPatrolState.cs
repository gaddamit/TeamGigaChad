using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    private int _currentPatrolPoint = 0;
    
    public EnemyPatrolState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log($"{_stateMachine.name} patroling");
    }

    public override void UpdateState()
    {
        Debug.Log("Patroling");
        _stateMachine.Target = _stateMachine.PatrolPoints[_currentPatrolPoint];
        SetTarget(_stateMachine.Target);

        if (IsInRadius(_stateMachine.PatrolPoints[_currentPatrolPoint], 0.3f))
        {
            
            _currentPatrolPoint++;
            _currentPatrolPoint %= _stateMachine.PatrolPoints.Length;
            Debug.Log("Next patrol point " + _currentPatrolPoint );

            //SetTarget(_stateMachine.PatrolPoints[_currentPatrolPoint]);
            _stateMachine.Target = null;
            _stateMachine.ChangeState(_stateMachine.IdleState);
        }

        //if (_stateMachine.Target != _stateMachine.PatrolPoints[_currentPatrolPoint])
        //{
        //    Debug.Log("Target changed");
        //    _stateMachine.ChangeState(_stateMachine.IdleState);
        //}
    }
}
