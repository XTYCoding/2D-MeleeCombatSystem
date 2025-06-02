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
    public SkeletonHurtState hurtState;

    public float hurtStateDuration = 1f; // Duration of the hurt state in seconds

    protected override void Awake()
    {
        base.Awake();

        idleState = new SkeletonIdleState(stateMachine, this, "Idle", "IdleTrigger", this);
        patrolState = new SkeletonPatrolState(stateMachine, this, "Patrol", "PatrolTrigger", this);
        chaseState = new SkeletonChaseState(stateMachine, this, "Chase", "ChaseTrigger", this);
        attackState = new SkeletonAttackState(stateMachine, this, "Attack", "AttackTrigger", this);
        stunnedState = new SkeletonStunnedState(stateMachine, this, "Stunned", "StunnedTrigger", this);
        hurtState = new SkeletonHurtState(stateMachine, this, "Hurt", "HurtTrigger", this);
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

    public override void TakeDamage(Attack attack)
    {
        
        base.TakeDamage(attack);
        stateMachine.ChangeState(hurtState);
    }

    void OnDrawGizmos()
    {
        var box = GetComponent<BoxCollider2D>();
        if (box != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(box.offset, box.size);
        }
    }
    
}

