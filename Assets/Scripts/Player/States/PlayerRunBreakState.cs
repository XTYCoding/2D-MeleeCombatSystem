using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunBreakState : PlayerGroundState
{
    public PlayerRunBreakState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
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
        // 检查输入的X轴值，如果大于0且角色面朝左则切换到Turn状态
        if (inputXY.x > 0 && !player.facingRight) stateMachine.ChangeState(player.turnState);
        // 检查输入的X轴值，如果小于0且角色面朝右则切换到Turn状态
        if (inputXY.x < 0 && player.facingRight) stateMachine.ChangeState(player.turnState);
        //如果动画结束就切换到Idle状态
        if (animFinTrigger) stateMachine.ChangeState(player.idleState);
    }

    public override void PhysicsUpdate()
    {
        player.SetZeroVelocity();
    }
}
