using System;
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
    
    public virtual void Enter() {}

    public virtual void UpdateState() {}

    public virtual void PhysicsUpdate() {}

    public virtual void ExitState() {}
    

    protected void RotateToPoint(GameObject target)
    {
        _stateMachine.transform.rotation = Quaternion.Lerp(_stateMachine.transform.rotation, Quaternion.LookRotation(target.transform.position - _stateMachine.transform.position), 7.5f * Time.fixedDeltaTime);
    }

    protected void SetTarget(GameObject target)
    {
        _stateMachine.Agent.destination = target.transform.position;
    }

    protected bool IsInRadius(GameObject target, float distanceCheck)
    {
        float distance = Vector3.Distance(_stateMachine.transform.position, target.transform.position);
        return distance < distanceCheck;
    }
}
