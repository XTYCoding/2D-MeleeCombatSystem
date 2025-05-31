using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.Collections.AllocatorManager;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        playerInput.GamePlay.Jump.started += Jump;
        playerInput.GamePlay.Dash.started += Dash;
        playerInput.GamePlay.BackDash.started += BackDash;
        playerInput.GamePlay.LightAttack.started += LightAttack;
        playerInput.GamePlay.HeavyAttack.started += HeavyAttack;
        playerInput.GamePlay.Block.started += Block;
    }



    private void Block(InputAction.CallbackContext context)
    {
        if(physicsCheck.isGrounded) stateMachine.ChangeState(player.blockState);
    }

    private void HeavyAttack(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGrounded) stateMachine.ChangeState(player.heavyAttackState);
    }

    private void LightAttack(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGrounded)
        {
            
            stateMachine.ChangeState(player.lightAttackState);
        }
    }

    private void BackDash(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGrounded)
            stateMachine.ChangeState(player.backDashState);
    }

    private void Dash(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGrounded)
            stateMachine.ChangeState(player.dashState);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if(physicsCheck.isGrounded)
            stateMachine.ChangeState(player.jumpState);
    }

    public override void Exit()
    {
        base.Exit();
        playerInput.GamePlay.Jump.started -= Jump;
        playerInput.GamePlay.Dash.started -= Dash;
        playerInput.GamePlay.BackDash.started -= BackDash;
        playerInput.GamePlay.LightAttack.started -= LightAttack;
        playerInput.GamePlay.HeavyAttack.started -= HeavyAttack;
        playerInput.GamePlay.Block.started -= Block;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!physicsCheck.isGrounded) stateMachine.ChangeState(player.fallState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
