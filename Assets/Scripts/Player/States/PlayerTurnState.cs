using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : PlayerGroundState
{
    public PlayerTurnState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
       // player.Flip();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //如果动画结束就切换到Run状态
        if (animFinTrigger) stateMachine.ChangeState(player.runState);
    }

    public override void PhysicsUpdate()
    {
        player.SetZeroVelocity();
    }
}
