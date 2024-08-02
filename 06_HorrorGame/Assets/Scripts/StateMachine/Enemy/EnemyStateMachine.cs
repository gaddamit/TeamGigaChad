using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{
    public IState CurrentState { get; private set; }
    
    #region States
    public EnemyIdleState IdleState;
    public EnemyPatrolState PatrolState;
    public EnemyChaseState ChaseState;
    #endregion
    
    #region Serialized Variables
    [field: SerializeField] public float patrolSpeed { get; private set; } = 3f;
    [field: SerializeField] public float chaseSpeed { get; private set; } = 5f;
    #endregion
    
    #region Components
    public NavMeshAgent Agent { get; private set; }
    #endregion

    #region State Relatedf Events
    public event Action OnPlayerDetected;
    #endregion

    public GameObject Target = null;

    public event Action<IState> StateChanged;

    [field: SerializeField] public GameObject[] PatrolPoints { get; private set; }

    public EnemyStateMachine()
    {
        this.IdleState = new EnemyIdleState(this);
        this.PatrolState = new EnemyPatrolState(this);
        this.ChaseState = new EnemyChaseState(this);
    }

    private void Awake()
    {
        InitializeState(IdleState);
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.UpdateState();
    }

    private void FixedUpdate()
    {
        CurrentState.PhysicsUpdate();
    }

    public void ChangeState(IState newState)
    {
        CurrentState.ExitState();
        CurrentState = newState;
        newState.Enter();
        
        StateChanged?.Invoke(newState);
    }

    void InitializeState(IState firstState)
    {
        if (CurrentState != null) { return; }
        
        CurrentState = firstState;
        firstState.Enter();
        
        StateChanged?.Invoke(firstState);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerDetected?.Invoke();
        }
    }
}
