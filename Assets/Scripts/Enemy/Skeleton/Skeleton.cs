using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public SkeletonIdleState idleState;
    public SkeletonPatrolState patrolState;

    protected override void Awake()
    {
        base.Awake();

        idleState = new SkeletonIdleState(stateMachine, this, "Idle", "IdleTrigger", this);
        patrolState = new SkeletonPatrolState(stateMachine, this, "Patrol", "PatrolTrigger", this);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(patrolState);
    }

    protected override void Update()
    {
        base.Update();
    }
}

