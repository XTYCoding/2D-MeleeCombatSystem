using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashAttackState : PlayerState
{
    public PlayerDashAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        rigidBody.AddForce(new Vector2(player.facingDir * player.jumpForce, 0), ForceMode2D.Impulse);
    }

    public override void Exit()
    {
        base.Exit();
        player.SetZeroVelocity(); // Reset velocity after lunge attack
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (animFinTrigger) stateMachine.ChangeState(player.idleState);
    }

    public override void PhysicsUpdate()
    {
        // No additional physics updates needed for lunge attack
        // The velocity is already set in Enter method
    }
}
