using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public EnemyChaseState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log($"{_stateMachine.name} Entering Chase State");
        TargetDetected += ChaseTarget;
    }

    public override void PhysicsUpdate()
    {
        Move(_stateMachine.transform.forward * _stateMachine.chaseSpeed);
    }

    void ChaseTarget(GameObject target)
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
}
