using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStunnedState : SkeletonState
{
    public SkeletonStunnedState(EnemyStateMachine stateMachine, Enemy enemy, string animBoolName, string animTriggerName, Skeleton skeleton) : base(stateMachine, enemy, animBoolName, animTriggerName, skeleton)
    {
    }
    public override void Enter()
    {
        base.Enter();
        enemy.SetZeroVelocity();
        rigidBody.AddForce(-enemy.facingDir*Vector2.right, ForceMode2D.Impulse);
        stateTimeer = 1f;
    }
    public override void Exit()
    {
        base.Exit();
        enemy.Stunned = false;
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (stateTimeer <= 0)
        {
            stateMachine.ChangeState(skeleton.idleState);
        }
        else
        {
            stateTimeer -= Time.deltaTime;
        }
    }
    public override void PhysicsUpdate()
    {
       // enemy.SetZeroVelocity ();

    }

}
