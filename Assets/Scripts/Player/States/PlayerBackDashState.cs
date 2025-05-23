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
        rigidBody.AddForce(-player.facingDir*Vector2.right*player.jumpForce, ForceMode2D.Impulse);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (animFinTrigger) stateMachine.ChangeState(player.idleState);
    }

    public override void PhysicsUpdate()
    {
            player.SetVelocity(rigidBody.velocity.x, 0);
    }

}
