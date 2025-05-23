using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlockState : PlayerState
{
    public PlayerBlockState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        playerInput.GamePlay.Block.canceled += BlockCancel;
        player.SetZeroVelocity();
    }
    private void BlockCancel(InputAction.CallbackContext context)
    {
        if(physicsCheck.isGrounded) stateMachine.ChangeState(player.idleState);
    }

    public override void Exit()
    {
        base.Exit();
        playerInput.GamePlay.Block.canceled -= BlockCancel;
        player.isBlocking = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (animFinTrigger)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        player.SetZeroVelocity();
        
    }
}
