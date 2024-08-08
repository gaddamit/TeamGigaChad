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
        Debug.Log($"{_stateMachine.name} Idling");
    }

    public override void UpdateState()
    {
        //Debug.Log("Checking for target" + _stateMachine.Target.name);
        if(_stateMachine.Target == null)
        {
            if(_patrolCoroutine == null)
            {
                Debug.Log("No target found, starting patrol state");
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
