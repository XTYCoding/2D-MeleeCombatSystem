using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackState : SkeletonState
{
    public SkeletonAttackState(EnemyStateMachine stateMachine, Enemy enemy, string animBoolName, string animTriggerName, Skeleton skeleton) : base(stateMachine, enemy, animBoolName, animTriggerName, skeleton)
    {
    }

    public override void Enter()
    {
        base.Enter();
        animFinTrigger = false;
        enemy.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(animFinTrigger) stateMachine.ChangeState(skeleton.patrolState);
        // if (physicsCheck.playerContacted)
        // {
        //     stateMachine.ChangeState(this);
        // }
        // else stateMachine.ChangeState(skeleton.chaseState);
    }

    public override void PhysicsUpdate()
    {
 
    }
}
