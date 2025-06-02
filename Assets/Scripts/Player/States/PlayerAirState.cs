using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        playerInput.GamePlay.LightAttack.started += LightAttack;
    }

    private void LightAttack(InputAction.CallbackContext context)
    {
        if(player.canAirAttack)
            stateMachine.ChangeState(player.airAttackState);
    }

    public override void Exit()
    {
        base.Exit();
        playerInput.GamePlay.LightAttack.started -= LightAttack;
    }
}
