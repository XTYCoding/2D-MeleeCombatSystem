using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// 玩家轻攻击状态，继承自PlayerState
public class PlayerLightAttackState : PlayerState
{
    // 构造函数，初始化轻攻击状态
    public PlayerLightAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
    }

    // 进入轻攻击状态时调用
    public override void Enter()
    {
        base.Enter();
        player.comboCounter = 0; // 重置连击计数
        player.animator.SetInteger("ComboCounter", player.comboCounter); // 更新动画参数
        playerInput.GamePlay.LightAttack.started += LightAttack; // 注册轻攻击输入
        playerInput.GamePlay.HeavyAttack.started += HeavyAttack; // 注册重攻击输入
    }

    // 重攻击输入回调
    private void HeavyAttack(InputAction.CallbackContext context)
    {
        if (!player.isAttacking)
            stateMachine.ChangeState(player.heavyAttackState);
    }

    // 轻攻击输入回调
    private void LightAttack(InputAction.CallbackContext context)
    {
        if (!player.isAttacking)
        {
            player.comboCounter++; // 连击计数+1
            player.animator.SetInteger("ComboCounter", player.comboCounter); // 更新动画参数
            animator.SetTrigger("LightAttackTrigger"); // 触发轻攻击动画
        }
    }

    // 退出轻攻击状态时调用
    public override void Exit()
    {
        base.Exit();
        playerInput.GamePlay.LightAttack.started -= LightAttack; // 注销轻攻击输入
        playerInput.GamePlay.HeavyAttack.started -= HeavyAttack; // 注销重攻击输入
        player.isAttacking = false; // 重置攻击状态，用动画触发事件设置为true
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
        player.SetZeroVelocity(); // 攻击时速度归零
    }

}