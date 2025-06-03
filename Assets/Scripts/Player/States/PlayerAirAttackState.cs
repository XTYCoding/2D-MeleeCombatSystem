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
        player.canAirAttack = false; // 释放空中攻击后不能再攻击
    }
    public override void Exit()
    {
        base.Exit();
        player.SetZeroVelocity(); // 攻击结束重置速度
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (animFinTrigger) stateMachine.ChangeState(player.fallState);
    }
    public override void PhysicsUpdate()
    {
        player.SetZeroVelocity(); // 攻击时保持速度为零
    }
}
