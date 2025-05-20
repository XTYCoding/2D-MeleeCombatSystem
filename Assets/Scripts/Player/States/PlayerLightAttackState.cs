using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLightAttackState : PlayerState
{
    public PlayerLightAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.comboCounter = 0;
        player.animator.SetInteger("ComboCounter", player.comboCounter);
        playerInput.GamePlay.LightAttack.started += LightAttack;
        playerInput.GamePlay.HeavyAttack.started += HeavyAttack;
    }

    private void HeavyAttack(InputAction.CallbackContext context)
    {
        if (!player.isAttacking)
            stateMachine.ChangeState(player.heavyAttackState);
    }

    private void LightAttack(InputAction.CallbackContext context)
    {
        if (!player.isAttacking)
        {
            player.comboCounter++;
            player.animator.SetInteger("ComboCounter", player.comboCounter);
            animator.SetTrigger("LightAttackTrigger");
        }
    }

    public override void Exit()
    {
        base.Exit();

        playerInput.GamePlay.LightAttack.started -= LightAttack;
        playerInput.GamePlay.HeavyAttack.started -= HeavyAttack;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (animFinTrigger) stateMachine.ChangeState(player.idleState);
    }

    public override void PhysicsUpdate()
    {
        player.SetZeroVelocity();
    }

}
