using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// 玩家冲刺状态，继承自PlayerState
public class PlayerDashState : PlayerState
{
    // 构造函数，初始化冲刺状态
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
    }

    // 进入冲刺状态时调用
    public override void Enter()
    {
        base.Enter();
        player.playerInput.GamePlay.LightAttack.started += LightAttack; // 注册轻攻击输入，冲刺中可触发冲刺攻击
    }

    // 轻攻击输入回调，切换到冲刺攻击状态
    private void LightAttack(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(player.dashAttackState);
    }

    // 退出冲刺状态时调用
    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, rigidBody.velocity.y); // 冲刺结束后重置水平速度
        player.playerInput.GamePlay.LightAttack.started -= LightAttack; // 注销轻攻击输入
    }

    // 逻辑更新，每帧调用
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (animFinTrigger) stateMachine.ChangeState(player.idleState); // 动画完成后切换到待机状态
    }

    // 物理更新，每物理帧调用
    public override void PhysicsUpdate()
    {
        player.SetVelocity(player.facingDir*player.dashSpeed, 0); // 持续向前冲刺
    }
}