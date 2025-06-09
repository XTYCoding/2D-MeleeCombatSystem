using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerFallAttackState : PlayerState
{
    public PlayerFallAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetZeroVelocity();
        rigidBody.AddForce(new Vector2(0, -player.jumpForce));
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (physicsCheck.isGrounded && animFinTrigger) stateMachine.ChangeState(player.idleState);

    }
    public override void PhysicsUpdate()
    {

    }
    public override void Exit()
    {
        base.Exit();
    }
}
