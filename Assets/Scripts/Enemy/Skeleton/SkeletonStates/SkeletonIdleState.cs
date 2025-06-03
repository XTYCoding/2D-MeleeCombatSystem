using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : SkeletonState
{
    public SkeletonIdleState(EnemyStateMachine stateMachine, Enemy enemy, string animBoolName, string animTriggerName, Skeleton skeleton) : base(stateMachine, enemy, animBoolName, animTriggerName, skeleton)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetZeroVelocity();
        stateTimeer = 2f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(stateTimeer <= 0)
        {   
            enemy.Flip();
            stateMachine.ChangeState(skeleton.patrolState);
        }
        else
        {
            stateTimeer -= Time.deltaTime;
        }
    }

    public override void PhysicsUpdate()
    {
        
    }
}
