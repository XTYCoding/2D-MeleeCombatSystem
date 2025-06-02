using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.playerInput.GamePlay.LightAttack.started += LightAttack;
    }

    private void LightAttack(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(player.dashAttackState);
    }

    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, rigidBody.velocity.y); // Reset horizontal velocity after dash
        player.playerInput.GamePlay.LightAttack.started -= LightAttack;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (animFinTrigger) stateMachine.ChangeState(player.idleState);
    }

    public override void PhysicsUpdate()
    {
        player.SetVelocity(player.facingDir*player.dashSpeed, 0);
    }
}
