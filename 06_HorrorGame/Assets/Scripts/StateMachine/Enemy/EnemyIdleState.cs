using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    private Coroutine _patrolCoroutine;
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
    
    }

    public override void UpdateState()
    {
        if(_stateMachine.Target == null)
        {
            if(_patrolCoroutine == null)
            {
                _patrolCoroutine = _stateMachine.StartCoroutine(StartPatrolStateTimer());
            }
        }
        else if (_stateMachine.Target.CompareTag("Player"))
        {
            _stateMachine.ChangeState(_stateMachine.ChaseState);
        } 
    }

    // Starts the patrol timer if there is no target for the enemy ghost
    IEnumerator StartPatrolStateTimer()
    {
        yield return new WaitForSeconds(5f);
        _stateMachine.ChangeState(_stateMachine.PatrolState);
        _patrolCoroutine = null;
    }
}
