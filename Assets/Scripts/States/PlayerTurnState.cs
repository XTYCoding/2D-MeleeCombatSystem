using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : PlayerState
{
    public PlayerTurnState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
       // player.Flip();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(animFinTrigger) stateMachine.ChangeState(player.runState);
    }

    public override void PhysicsUpdate()
    {
        player.SetZeroVelocity();
    }
}
