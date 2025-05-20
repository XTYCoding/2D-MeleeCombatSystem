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
        
        if (inputXY.x > 0 && !player.facingRight) stateMachine.ChangeState(player.turnState);
        if (inputXY.x < 0 && player.facingRight) stateMachine.ChangeState(player.turnState);
        if (animFinTrigger) stateMachine.ChangeState(player.idleState);
    }

    public override void PhysicsUpdate()
    {
        player.SetZeroVelocity();
    }
}
