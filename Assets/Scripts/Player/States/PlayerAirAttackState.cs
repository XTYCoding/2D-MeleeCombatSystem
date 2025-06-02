using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirAttackState : PlayerState
{
    public PlayerAirAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.canAirAttack = false; // Disable air attack until the animation finishes
    }
    public override void Exit()
    {
        base.Exit();
        player.SetZeroVelocity(); // Reset velocity after air attack
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (animFinTrigger) stateMachine.ChangeState(player.fallState);
    }
    public override void PhysicsUpdate()
    {
        player.SetZeroVelocity(); // Reset velocity after air attack
    }
}
