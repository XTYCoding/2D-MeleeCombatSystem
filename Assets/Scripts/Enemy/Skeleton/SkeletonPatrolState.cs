using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkeletonPatrolState : SkeletonState
{
    public SkeletonPatrolState(EnemyStateMachine stateMachine, Enemy enemy, string animBoolName, string animTriggerName, Skeleton skeleton) : base(stateMachine, enemy, animBoolName, animTriggerName, skeleton)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(physicsCheck.playerDetected) stateMachine.ChangeState(skeleton.chaseState);
        if (!physicsCheck.isGrounded || physicsCheck.wallDetected){
            stateMachine.ChangeState(skeleton.idleState); }
    }

    public override void PhysicsUpdate()
    {
        enemy.SetVelocity(enemy.facingDir * enemy.moveSpeed * Time.deltaTime, 0);
    
    }
}
