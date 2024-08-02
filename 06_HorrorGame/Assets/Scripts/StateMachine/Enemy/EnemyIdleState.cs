using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log($"{_stateMachine.name} Idling");
    }

    public override void UpdateState()
    {
        if (_stateMachine.Target.CompareTag("Player"))
        {
            _stateMachine.ChangeState(_stateMachine.ChaseState);
        }
        else if (_stateMachine.Target == null)
        {
            _stateMachine.StartCoroutine(StartPatrolStateTimer());
        }
    }

    // Starts the patrol timer if there is no target for the enemy ghost
    IEnumerator StartPatrolStateTimer()
    {
        yield return new WaitForSeconds(5f);
        _stateMachine.ChangeState(_stateMachine.PatrolState);
    }
}
