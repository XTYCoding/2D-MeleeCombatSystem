using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHittedState : SkeletonState
{
    public SkeletonHittedState(EnemyStateMachine stateMachine, Enemy enemy, string animBoolName, string animTriggerName, Skeleton skeleton) : base(stateMachine, enemy, animBoolName, animTriggerName, skeleton)
    {
    }

    public override void Enter()
    {
        base.Enter();
        skeleton.SetZeroVelocity();
        skeleton.rigidBody.velocity = Vector2.zero;
        skeleton.rigidBody.isKinematic = true;
    }

    public override void Exit()
    {
        base.Exit();
        skeleton.rigidBody.isKinematic = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

