using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        rigidBody.AddForce(Vector2.up*player.jumpForce, ForceMode2D.Impulse);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (rigidBody.velocity.y < 0) stateMachine.ChangeState(player.fallState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
