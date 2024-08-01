using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : IState
{
    protected EnemyStateMachine _stateMachine;

    public event Action<GameObject> TargetDetected;
    
    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    
    public virtual void Enter() {}

    public virtual void UpdateState() {}

    public virtual void PhysicsUpdate() {}

    public virtual void ExitState() {}

    protected void Move(Vector3 motion)
    {
        _stateMachine.transform.position = Vector3.Lerp(_stateMachine.transform.position, motion, Time.fixedDeltaTime);
    }

    protected void RotateToPoint(GameObject target)
    {
        _stateMachine.transform.rotation = Quaternion.Lerp(_stateMachine.transform.rotation, Quaternion.LookRotation(target.transform.position - _stateMachine.transform.position), 7.5f * Time.fixedDeltaTime);
    }

    protected void SetTarget(GameObject target)
    {
        TargetDetected?.Invoke(target);
    }
}
