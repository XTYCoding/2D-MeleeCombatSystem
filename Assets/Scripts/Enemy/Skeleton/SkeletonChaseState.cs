using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonChaseState : SkeletonState
{
    public SkeletonChaseState(EnemyStateMachine stateMachine, Enemy enemy, string animBoolName, string animTriggerName, Skeleton skeleton) : base(stateMachine, enemy, animBoolName, animTriggerName, skeleton)
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
        
        if (physicsCheck.playerContacted)
        {
            stateMachine.ChangeState(skeleton.attackState);
        }
        else if (!physicsCheck.playerDetected)
        {
            stateMachine.ChangeState(skeleton.patrolState);
        }
    }

    public override void PhysicsUpdate()
    {
        if(enemy.transform.position.x>= enemy.player.position.x)
        {
            enemy.SetVelocity(2*Vector2.left * enemy.moveSpeed * Time.deltaTime);
        }
        else if(enemy.transform.position.x<enemy.player.position.x)
        {
            enemy.SetVelocity(2*Vector2.right * enemy.moveSpeed * Time.deltaTime);
        }
    }
}


