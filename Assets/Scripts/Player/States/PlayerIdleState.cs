using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
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
        //如果输入的X轴大于0.1，则切换到行走状态
        if (Mathf.Abs(inputXY.x) > 0.1) stateMachine.ChangeState(player.walkState);
    }

    public override void PhysicsUpdate()
    {
        //base.PhysicsUpdate();
    }
}
