using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackDashState : PlayerState
{
    public PlayerBackDashState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.noFlip = true; // Disable flipping during back dash
       
    }

    public override void Exit()
    {
        base.Exit();
        player.noFlip = false; // Re-enable flipping after back dash
         player.SetVelocity(0, rigidBody.velocity.y); 
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (animFinTrigger) stateMachine.ChangeState(player.idleState);
    }

    public override void PhysicsUpdate()
    {
        player.SetVelocity(-player.facingDir*player.dashSpeed, 0);
    }

}
