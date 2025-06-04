using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDeadState : SkeletonState
{
    public SkeletonDeadState(EnemyStateMachine stateMachine, Enemy enemy, string animBoolName, string animTriggerName, Skeleton skeleton) : base(stateMachine, enemy, animBoolName, animTriggerName, skeleton)
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
        // 可以添加死亡后的逻辑处理，比如掉落物品等
    }

    public override void PhysicsUpdate()
    {
        skeleton.SetZeroVelocity();
        // 在死亡状态下通常不需要物理更新
    }

}
