using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public SkeletonIdleState idleState;
    public SkeletonPatrolState patrolState;
    public SkeletonChaseState chaseState;
    public SkeletonAttackState attackState;
    public SkeletonStunnedState stunnedState;

    protected override void Awake()
    {
        base.Awake();

        idleState = new SkeletonIdleState(stateMachine, this, "Idle", "IdleTrigger", this);
        patrolState = new SkeletonPatrolState(stateMachine, this, "Patrol", "PatrolTrigger", this);
        chaseState = new SkeletonChaseState(stateMachine, this, "Chase", "ChaseTrigger", this);
        attackState = new SkeletonAttackState(stateMachine, this, "Attack", "AttackTrigger", this);
        stunnedState = new SkeletonStunnedState(stateMachine, this, "Stunned", "StunnedTrigger", this);
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

